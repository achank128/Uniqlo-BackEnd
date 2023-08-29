using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.BusinessLogic.Shared.ClaimService;
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
        private readonly IClaimService _claimService;
        private readonly ICartRepository _cartRepository;
        private readonly IRepositoryBase<CartItem> _cartItemRepository;


        public CartService(
            IMapper mapper, 
            IClaimService claimService, 
            ICartRepository cartRepository, 
            IRepositoryBase<CartItem> cartItemRepository
            )
        {
            _mapper = mapper;
            _claimService = claimService;
            _cartRepository = cartRepository;
            _cartItemRepository = cartItemRepository;
        }

        public async Task<ApiResponse<CartResponse>> Create(CreateCartRequest request)
        {
            var cart = _mapper.Map<Cart>(request);
            _cartRepository.Add(cart);

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

        public async Task<PagedResponse<CartResponse>> GetAll(FilterBaseRequest request)
        {
            var carts = _cartRepository.GetQueryable();
            var paged = await PagedResponse<Cart>.CreateAsync(carts, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<CartResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<CartResponse>> GetById(Guid id)
        {
            var cart = await _cartRepository.GetCartByIdAsync(id);
            if (cart == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<CartResponse>(cart);
            return ApiResponse<CartResponse>.Success(response);
        }

        public async Task<ApiResponse<CartResponse>> GetByUser()
        {
            var userId = _claimService.GetUserId();
            var userCart = _cartRepository.GetCartByUser(userId);
            if(userCart == null)
            {
                Cart newCart = new Cart { 
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Amount = 0,
                };
                _cartRepository.Add(newCart);
                await _cartRepository.SaveAsync();

                var cart = await _cartRepository.GetCartByIdAsync(newCart.Id);
                if (cart == null) throw new NotFoundException(Common.NotFound);

                var res = _mapper.Map<CartResponse>(cart);
                return ApiResponse<CartResponse>.Success(res);
            }

            var response = _mapper.Map<CartResponse>(userCart);
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
