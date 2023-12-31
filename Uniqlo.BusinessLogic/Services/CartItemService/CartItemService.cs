﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.BusinessLogic.Shared.ClaimService;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.CartItem;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CartItemService
{
    public class CartItemService : ICartItemService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<CartItem> _cartItemRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IProductRepository _productRepository;
        private readonly IProductDetailRepository _productDetailRepository;


        public CartItemService(
            IMapper mapper,
            IClaimService claimService,
            IRepositoryBase<CartItem> cartItemRepository,
            ICartRepository cartRepository,
            IProductRepository productRepository,
            IProductDetailRepository productDetailRepository)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
            _productDetailRepository = productDetailRepository;
        }

        public async Task<ApiResponse<CartItemResponse>> Create(CreateCartItemRequest request)
        {
            var cartItem = _mapper.Map<CartItem>(request);
            _cartItemRepository.Add(cartItem);
            
            var cart = await _cartRepository.GetByIdAsync(cartItem.CartId);
            cart.Amount += cartItem.Quantity;

            if (await _cartItemRepository.SaveAsync())
            {
                cartItem.ProductDetail = await _productDetailRepository.GetByIdAsync(cartItem.ProductDetailId);
                var product = await _productRepository.GetProductById(cartItem.ProductDetail.ProductId);
                var response = _mapper.Map<CartItemResponse>(cartItem);
                response.Product = _mapper.Map<ProductResponse>(product);
                return ApiResponse<CartItemResponse>.Success(Common.CreateSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<CartItemResponse>> Delete(Guid id)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(id);
            if (cartItem == null) throw new NotFoundException(Common.NotFound);

            var cart = await _cartRepository.GetByIdAsync(cartItem.CartId);
            cart.Amount -= cartItem.Quantity;

            _cartItemRepository.Delete(cartItem);
            if (await _cartItemRepository.SaveAsync())
            {
                return ApiResponse<CartItemResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<CartItemResponse>> Filter(FilterBaseRequest request)
        {
            var cartItems = _cartItemRepository.GetQueryable();
            var paged = await PagedResponse<CartItem>.CreateAsync(cartItems, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<CartItemResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<CartItemResponse>>> GetAll()
        {
            var alls = await _cartItemRepository.GetAllAsync();
            var response = _mapper.Map<List<CartItemResponse>>(alls);
            return ApiResponse<List<CartItemResponse>>.Success(response);
        }

        public async Task<ApiResponse<CartItemResponse>> GetById(Guid id)
        {
            var cartItem = await _cartItemRepository
                        .GetBy(s => s.Id == id)
                        .Include(s => s.ProductDetail)
                        .ThenInclude(s => s.Product)
                        .SingleOrDefaultAsync();
                ;
            if (cartItem == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<CartItemResponse>(cartItem);
            return ApiResponse<CartItemResponse>.Success(response);
        }

        public async Task<ApiResponse<CartItemResponse>> Update(UpdateCartItemRequest request)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(request.Id);
            if (cartItem == null) throw new NotFoundException(Common.NotFound);

            var cart = await _cartRepository.GetByIdAsync(cartItem.CartId);
            cart.Amount -= cartItem.Quantity;
            cart.Amount += request.Quantity;

            cartItem.CartId = request.CartId;
            cartItem.ProductDetailId = request.ProductDetailId;
            cartItem.Quantity = request.Quantity;
            cartItem.UpdatedDate = DateTime.Now;

            if (await _cartItemRepository.SaveAsync())
            {
                return ApiResponse<CartItemResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<ApiResponse<CartItemResponse>> UpdateQuantity(UpdateQuantityCartItemRequest request)
        {
            var cartItem = await _cartItemRepository.GetByIdAsync(request.Id);
            if (cartItem == null) throw new NotFoundException(Common.NotFound);

            var cart = await _cartRepository.GetByIdAsync(cartItem.CartId);
            cart.Amount -= cartItem.Quantity;
            cart.Amount += request.Quantity;

            cartItem.Quantity = request.Quantity;
            cartItem.UpdatedDate = DateTime.Now;

            if (await _cartItemRepository.SaveAsync())
            {
                var response = _mapper.Map<CartItemResponse>(cartItem);
                return ApiResponse<CartItemResponse>.Success(Common.UpdateSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }
    }
}
