using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Cart;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CartService
{
    public class CartService : ICartService
    {
        private readonly IMapper _mapper;
        private readonly ICartRepository _cartRepository;
        private readonly IRepositoryBase<CartItem> _cartItemRepository;
        private readonly IProductRepository _productRepository;


        public CartService(
            IMapper mapper,
            ICartRepository cartRepository,
            IRepositoryBase<CartItem> cartItemRepository,
            IProductRepository productRepository)
        {
            _mapper = mapper;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<CartResponse>> ClearItem(Guid id)
        {
            var cartItems = await _cartItemRepository.GetBy(s => s.CartId == id).ToListAsync();
            _cartItemRepository.DeleteRange(cartItems);

            if (await _cartRepository.SaveAsync())
            {
                return ApiResponse<CartResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }

        }

        public async Task<ApiResponse<CartResponse>> Create(CreateCartRequest request)
        {
            var cart = _mapper.Map<Cart>(request);
             _cartRepository.CreateCart(cart);

            if (await _cartRepository.SaveAsync())
            {
                return ApiResponse<CartResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<CartResponse>> Delete(Guid id, DeleteRequest request)
        {
            var cart = await _cartRepository.GetByIdAsync(id);
            if (cart == null) throw new NotFoundException(Common.NotFound);

            cart.DeleteStatus = true;
            if (await _cartRepository.SaveAsync())
            {
                return ApiResponse<CartResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<CartResponse>> Filter(FilterBaseRequest request)
        {
            var carts = _cartRepository.GetQueryable();
            var paged = await PagedResponse<Cart>.CreateAsync(carts, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<CartResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<CartResponse>>> GetAll()
        {
            var alls = await _cartRepository.GetAllAsync();
            var response = _mapper.Map<List<CartResponse>>(alls);
            return ApiResponse<List<CartResponse>>.Success(response);
        }

        public async Task<ApiResponse<CartResponse>> GetById(Guid id)
        {
            var cart = await _cartRepository.GetCartById(id);
            if (cart == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<CartResponse>(cart);
            return ApiResponse<CartResponse>.Success(response);
        }

        public async Task<ApiResponse<CartResponse>> GetByUser(Guid userId)
        {
            var userCart = await _cartRepository.GetCartByUser(userId);
            if(userCart == null)
            {
                Cart newCart = new Cart { 
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Amount = 0,
                };
                _cartRepository.Add(newCart);
                await _cartRepository.SaveAsync();

                var res = _mapper.Map<CartResponse>(newCart);
                return ApiResponse<CartResponse>.Success(res);
            }

            var response = _mapper.Map<CartResponse>(userCart);
            foreach (var item in response.CartItems) {
                var product = await _productRepository.GetProductById(item.ProductDetail.ProductId);
                item.Product = _mapper.Map<ProductResponse>(product);
            }

            return ApiResponse<CartResponse>.Success(response);
        }

        public async Task<ApiResponse<CartResponse>> Update(UpdateCartRequest request)
        {
            _cartRepository.DeleteItemsFormCart(request.Id);
            var cartItems = _mapper.Map<List<CartItem>>(request.CartItems);
            _cartItemRepository.AddRange(cartItems);
            var cart = _mapper.Map<Cart>(request);
            cart.UpdatedDate = DateTime.Now;
            _cartRepository.Update(cart);
            if (await _cartRepository.SaveAsync())
            {
                return ApiResponse<CartResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
