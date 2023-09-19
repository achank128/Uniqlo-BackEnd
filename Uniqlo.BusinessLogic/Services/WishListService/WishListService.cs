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
using Uniqlo.Models.RequestModels.WishList;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.WishListService
{
    public class WishListService : IWishListService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<WishList> _wishListRepository;
        private readonly IProductRepository _productRepository;

        public WishListService(
            IRepositoryBase<WishList> wishListRepository, 
            IMapper mapper, 
            IProductRepository productRepository)
        {
            _wishListRepository = wishListRepository;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ApiResponse<WishListResponse>> Create(CreateWishListRequest request)
        {
            var wishList = _mapper.Map<WishList>(request);
            _wishListRepository.Add(wishList);

            if (await _wishListRepository.SaveAsync())
            {
                var response = _mapper.Map<WishListResponse>(wishList);
                return ApiResponse<WishListResponse>.Success(Common.CreateSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<WishListResponse>> Delete(Guid id)
        {
            var wishlist = await _wishListRepository.GetByIdAsync(id);
            if (wishlist == null) throw new NotFoundException(Common.NotFound);

            _wishListRepository.Delete(wishlist);
            if (await _wishListRepository.SaveAsync())
            {
                return ApiResponse<WishListResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<WishListResponse>> Filter(FilterBaseRequest request)
        {
            var usercoupons = _wishListRepository.GetQueryable().Include(s => s.Product);
            var paged = await PagedResponse<WishList>.CreateAsync(usercoupons, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<WishListResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<WishListResponse>>> GetAll()
        {
            var alls = await _wishListRepository.GetAllAsync();
            var response = _mapper.Map<List<WishListResponse>>(alls);
            return ApiResponse<List<WishListResponse>>.Success(response);
        }

        public async Task<ApiResponse<List<WishListResponse>>> GetUserWishList(Guid userId)
        {
            var wishList = await _wishListRepository.GetBy(s => s.UserId == userId).ToListAsync();

            foreach(var wish in wishList)
            {
                wish.Product = await _productRepository.GetProductById(wish.ProductId);
            }

            var response = _mapper.Map<List<WishListResponse>>(wishList);
            return ApiResponse<List<WishListResponse>>.Success(response);
        }
    }
}
