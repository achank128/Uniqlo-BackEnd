using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.BusinessLogic.Shared.FileUploadService;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Collection;
using Uniqlo.Models.RequestModels.CollectionPost;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CollectionPostService
{
    public class CollectionPostService : ICollectionPostService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<CollectionPost> _collectionPostRepository;
        private readonly IFileUploadService _fileUploadService;

        public CollectionPostService(
            IRepositoryBase<CollectionPost> collectionPostRepository, 
            IMapper mapper, 
            IFileUploadService fileUploadService)
        {
            _collectionPostRepository = collectionPostRepository;
            _mapper = mapper;
            _fileUploadService = fileUploadService;
        }

        public async Task<ApiResponse<CollectionPostResponse>> Create(CreateCollectionPostRequest request)
        {
            var collectionPost = _mapper.Map<CollectionPost>(request);
            _collectionPostRepository.Add(collectionPost);

            if (await _collectionPostRepository.SaveAsync())
            {
                return ApiResponse<CollectionPostResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<CollectionPostResponse>> Delete(Guid id)
        {
            var collectionPost = await _collectionPostRepository.GetByIdAsync(id);
            if (collectionPost == null) throw new NotFoundException(Common.NotFound);

            _collectionPostRepository.DeleteBy(id);
            if (await _collectionPostRepository.SaveAsync())
            {
                return ApiResponse<CollectionPostResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<CollectionPostResponse>> Filter(FilterBaseRequest request)
        {
            var collectionPosts = _collectionPostRepository.GetQueryable();
            var paged = await PagedResponse<CollectionPost>.CreateAsync(collectionPosts, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<CollectionPostResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<CollectionPostResponse>>> GetAll()
        {
            var alls = await _collectionPostRepository.GetAllAsync();
            var response = _mapper.Map<List<CollectionPostResponse>>(alls);
            return ApiResponse<List<CollectionPostResponse>>.Success(response);
        }

        public async Task<ApiResponse<List<CollectionPostResponse>>> GetByCollection(Guid collectionId)
        {
            var collectionPosts = await _collectionPostRepository.GetBy(s => s.CollectionId == collectionId).ToListAsync();
            var response = _mapper.Map<List<CollectionPostResponse>>(collectionPosts);
            return ApiResponse<List<CollectionPostResponse>>.Success(response);
        }

        public async Task<ApiResponse<CollectionPostResponse>> GetById(Guid id)
        {
            var collection = await _collectionPostRepository.GetByIdAsync(id);
            if (collection == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<CollectionPostResponse>(collection);
            return ApiResponse<CollectionPostResponse>.Success(response);
        }

        public async Task<ApiResponse<CollectionPostResponse>> Update(UpdateCollectionPostRequest request)
        {
            var collection = _mapper.Map<CollectionPost>(request);
            collection.UpdatedDate = DateTime.Now;
            _collectionPostRepository.Update(collection);
            if (await _collectionPostRepository.SaveAsync())
            {
                return ApiResponse<CollectionPostResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }

        public async Task<ApiResponse<CollectionPostResponse>> Upload(UploadCollectionPostRequest request)
        {
            var fileUploaded = await _fileUploadService.PostFileAsync(request.Image);
            CollectionPost collectionPost = new CollectionPost
            {
                Id = Guid.NewGuid(),
                CollectionId = request.CollectionId,
                Title = request.Title,
                TitleEn = request.TitleEn,
                TitleVi = request.TitleVi,
                Description = request.Description,
                DescriptionEn = request.DescriptionEn,
                DescriptionVi = request.DescriptionVi,
                Type = request.Type,
                Image = fileUploaded.FileName,
                ImageUrl = fileUploaded.FilePath,
            };

            _collectionPostRepository.Add(collectionPost);
            if (await _collectionPostRepository.SaveAsync())
            {
                var response = _mapper.Map<CollectionPostResponse>(collectionPost);
                return ApiResponse<CollectionPostResponse>.Success(Common.UpdateSuccess, response);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
