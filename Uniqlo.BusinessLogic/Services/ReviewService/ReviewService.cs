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
using Uniqlo.Models.RequestModels.Review;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.ReviewService
{
    public class ReviewService : IReviewService
    {
        private readonly IMapper _mapper;
        private readonly IReviewRepository _reviewRepository;

        public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
        {
            _mapper = mapper;
            _reviewRepository = reviewRepository;
        }

        public async Task<ApiResponse<ReviewResponse>> Create(CreateReviewRequest request)
        {
            var review = _mapper.Map<Review>(request);
            _reviewRepository.Add(review);

            if (await _reviewRepository.SaveAsync())
            {
                return ApiResponse<ReviewResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<ReviewResponse>> Delete(Guid id)
        {
            var review = await _reviewRepository.GetByIdAsync(id);
            if (review == null) throw new NotFoundException(Common.NotFound);

            _reviewRepository.Delete(review);
            if (await _reviewRepository.SaveAsync())
            {
                return ApiResponse<ReviewResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<ReviewResponse>> Filter(FilterReviewRequest request)
        {
            var reviews = _reviewRepository.FilterReviews(request);
            var paged = await PagedResponse<Review>.CreateAsync(reviews, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<ReviewResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<ReviewResponse>>> GetAll()
        {
            var alls = await _reviewRepository.GetAllAsync();
            var response = _mapper.Map<List<ReviewResponse>>(alls);
            return ApiResponse<List<ReviewResponse>>.Success(response);
        }

        public async Task<ApiResponse<ReviewResponse>> GetById(Guid id)
        {
            var review = await _reviewRepository.GetReviewById(id);
            if (review == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<ReviewResponse>(review);
            return ApiResponse<ReviewResponse>.Success(response);
        }

        public async Task<ApiResponse<List<ReviewResponse>>> GetByUser(Guid userId)
        {
            var reviews = await _reviewRepository.GetBy(r => r.UserId == userId).ToListAsync();
            var response = _mapper.Map<List<ReviewResponse>>(reviews);
            return ApiResponse<List<ReviewResponse>>.Success(response);
        }

        public async Task<ApiResponse<ReviewResponse>> Update(UpdateReviewRequest request)
        {
            var review = _mapper.Map<Review>(request);
            review.UpdatedDate = DateTime.Now;
            _reviewRepository.Update(review);
            if (await _reviewRepository.SaveAsync())
            {
                return ApiResponse<ReviewResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
