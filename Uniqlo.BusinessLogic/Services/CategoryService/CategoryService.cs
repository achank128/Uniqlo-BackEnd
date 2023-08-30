using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Category;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<CategoryResponse>> Create(CreateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            _categoryRepository.Add(category);

            if (await _categoryRepository.SaveAsync())
            {
                return ApiResponse<CategoryResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<CategoryResponse>> Delete(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException(Common.NotFound);

            _categoryRepository.DeleteBy(id);
            if (await _categoryRepository.SaveAsync())
            {
                return ApiResponse<CategoryResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<CategoryResponse>> Filter(FilterBaseRequest request)
        {
            var categories = _categoryRepository.GetQueryable();
            var paged = await PagedResponse<Category>.CreateAsync(categories, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<CategoryResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<CategoryResponse>>> GetAll()
        {
            var alls = await _categoryRepository.GetAllAsync();
            var response = _mapper.Map<List<CategoryResponse>>(alls);
            return ApiResponse<List<CategoryResponse>>.Success(response);
        }

        public async Task<ApiResponse<CategoryResponse>> GetById(Guid id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<CategoryResponse>(category);
            return ApiResponse<CategoryResponse>.Success(response);
        }

        public async Task<ApiResponse<CategoryResponse>> Update(UpdateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            category.UpdatedDate = DateTime.Now;
            _categoryRepository.Update(category);
            if (await _categoryRepository.SaveAsync())
            {
                return ApiResponse<CategoryResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
