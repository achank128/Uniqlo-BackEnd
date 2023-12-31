﻿using AutoMapper;
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
using Uniqlo.Models.RequestModels.Coupon;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.UserCouponService
{
    public class UserCouponService : IUserCouponService
    {
        private readonly IRepositoryBase<UserCoupon> _userCouponRepository;
        private readonly ICouponRepository _couponRepository;
        private readonly IMapper _mapper;

        public UserCouponService(
            IRepositoryBase<UserCoupon> userCouponRepository, 
            IMapper mapper, 
            ICouponRepository couponRepository)
        {
            _userCouponRepository = userCouponRepository;
            _mapper = mapper;
            _couponRepository = couponRepository;
        }

        public async Task<ApiResponse<UserCouponResponse>> AddUserCoupon(Guid userId, string couponCode)
        {
            var coupon = await _couponRepository.GetBy(c => c.Code == couponCode).FirstOrDefaultAsync();
            if(coupon == null) throw new NotFoundException(Common.NotFound);
            UserCoupon userCoupon = new UserCoupon
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                CouponId = coupon.Id
            };
            _userCouponRepository.Add(userCoupon);
            if (await _userCouponRepository.SaveAsync())
            {
                return ApiResponse<UserCouponResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<UserCouponResponse>> CreateUserCoupon(CreateUserCouponRequest request)
        {
            var userCoupon = _mapper.Map<UserCoupon>(request);
            _userCouponRepository.Add(userCoupon);

            if (await _userCouponRepository.SaveAsync())
            {
                return ApiResponse<UserCouponResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<UserCouponResponse>> DeleteUserCoupon(Guid id)
        {
            var userCoupon = await _userCouponRepository.GetByIdAsync(id);
            if (userCoupon == null) throw new NotFoundException(Common.NotFound);

            _userCouponRepository.Delete(userCoupon);
            if (await _userCouponRepository.SaveAsync())
            {
                return ApiResponse<UserCouponResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<UserCouponResponse>> Filter(FilterBaseRequest request)
        {
            var categories = _userCouponRepository.GetQueryable().Include(s => s.Coupon);
            var paged = await PagedResponse<UserCoupon>.CreateAsync(categories, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<UserCouponResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<UserCouponResponse>>> GetAll()
        {
            var alls = await _userCouponRepository.GetAllAsync();
            var response = _mapper.Map<List<UserCouponResponse>>(alls);
            return ApiResponse<List<UserCouponResponse>>.Success(response);
        }

        public async Task<ApiResponse<List<UserCouponResponse>>> GetUserCoupons(Guid userId)
        {
            var coupons = await _userCouponRepository.GetBy(s => s.UserId == userId).Include(s => s.Coupon).ToListAsync();
            var response = _mapper.Map<List<UserCouponResponse>>(coupons);
            return ApiResponse<List<UserCouponResponse>>.Success(response);
        }
    }
}
