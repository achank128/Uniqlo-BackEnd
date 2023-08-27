using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.BusinessLogic.Services.Interfaces;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.CouponRepository;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Coupon;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.Implements
{
    public class CouponService : ICouponService
    {
        private readonly IMapper _mapper;
        private readonly ICouponRepository _couponRepository;

        public CouponService(ICouponRepository couponRepository, IMapper mapper)
        {
            _couponRepository = couponRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CouponResponse>> Create(CreateCouponRequest request)
        {
            var coupon = _mapper.Map<Coupon>(request);
            _couponRepository.Add(coupon);

            if (await _couponRepository.SaveAsync())
            {
                return ApiResponse<CouponResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<CouponResponse>> Delete(Guid id)
        {
            var coupon = await _couponRepository.GetByIdAsync(id);
            if (coupon == null) throw new NotFoundException(Common.NotFound);

            _couponRepository.DeleteBy(id);
            if (await _couponRepository.SaveAsync())
            {
                return ApiResponse<CouponResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<CouponResponse>> GetAll(FilterBaseRequest request)
        {
            var coupons = _couponRepository.GetQueryable();
            var paged = await PagedResponse<Coupon>.CreateAsync(coupons, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<CouponResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<CouponResponse>> GetById(Guid id)
        {
            var coupon = await _couponRepository.GetByIdAsync(id);
            if (coupon == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<CouponResponse>(coupon);
            return ApiResponse<CouponResponse>.Success(response);
        }

        public async Task<ApiResponse<CouponResponse>> Update(UpdateCouponRequest request)
        {
            var coupon = _mapper.Map<Coupon>(request);
            coupon.UpdatedDate = DateTime.Now;
            _couponRepository.Update(coupon);
            if (await _couponRepository.SaveAsync())
            {
                return ApiResponse<CouponResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
