using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.WishListService
{
    public class WishListService : IWishListService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<WishList> _wishListRepository;

        public WishListService(IRepositoryBase<WishList> wishListRepository, IMapper mapper)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<WishListResponse>> AddWishList(Guid userId, Guid productId)
        {
            WishList wishList = new WishList
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                ProductId = productId
            };
            _wishListRepository.Add(wishList);

            if (await _wishListRepository.SaveAsync())
            {
                return ApiResponse<WishListResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<WishListResponse>> Delete(Guid id)
        {
            var userCoupon = await _wishListRepository.GetByIdAsync(id);
            if (userCoupon == null) throw new NotFoundException(Common.NotFound);

            _wishListRepository.Delete(userCoupon);
            if (await _wishListRepository.SaveAsync())
            {
                return ApiResponse<WishListResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<WishListResponse>> GetAll(FilterBaseRequest request)
        {
            var usercoupons = _wishListRepository.GetQueryable().Include(s => s.Product);
            var paged = await PagedResponse<WishList>.CreateAsync(usercoupons, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<WishListResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<WishListResponse>>> GetUserWishList(Guid userId)
        {
            var wishList = await _wishListRepository.GetBy(s => s.UserId == userId).Include(s => s.Product).ToListAsync();
            var response = _mapper.Map<List<WishListResponse>>(wishList);
            return ApiResponse<List<WishListResponse>>.Success(response);
        }
    }
}
