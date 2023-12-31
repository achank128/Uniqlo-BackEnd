﻿using AutoMapper;
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
using Uniqlo.Models.RequestModels.Collection;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CollectionService
{
    public class CollectionService : ICollectionService
    {
        private readonly IMapper _mapper;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IRepositoryBase<CollectionPost> _collectionPostRepository;


        public CollectionService(
            ICollectionRepository collectionRepository, 
            IMapper mapper, 
            IRepositoryBase<CollectionPost> collectionPostRepository)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
            _collectionPostRepository = collectionPostRepository;
        }

        public async Task<ApiResponse<CollectionResponse>> Create(CreateCollectionRequest request)
        {
            var collection = _mapper.Map<Collection>(request);
            _collectionRepository.Add(collection);

            if (await _collectionRepository.SaveAsync())
            {
                return ApiResponse<CollectionResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<CollectionResponse>> CreateFull(CreateCollectionFullRequest request)
        {
            var collection = _mapper.Map<Collection>(request);
            collection.Id = Guid.NewGuid();

            List<CollectionPost> collectionPosts = new List<CollectionPost>();
            foreach (var post in request.Posts)
            {
                CollectionPost collectionPost = _mapper.Map<CollectionPost>(post);
                collectionPost.Id = Guid.NewGuid();
                collectionPost.CollectionId = collection.Id;
                collectionPosts.Add(collectionPost);
            }
            
            _collectionPostRepository.AddRange(collectionPosts);
            _collectionRepository.Add(collection);

            if (await _collectionRepository.SaveAsync())
            {
                return ApiResponse<CollectionResponse>.Success(Common.CreateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.CreateFailure);
            }
        }

        public async Task<ApiResponse<CollectionResponse>> Delete(Guid id)
        {
            var collection = await _collectionRepository.GetByIdAsync(id);
            if (collection == null) throw new NotFoundException(Common.NotFound);

            _collectionRepository.DeleteBy(id);
            if (await _collectionRepository.SaveAsync())
            {
                return ApiResponse<CollectionResponse>.Success(Common.DeleteSuccess);
            }
            else
            {
                throw new BadRequestException(Common.DeleteFailure);
            }
        }

        public async Task<PagedResponse<CollectionResponse>> Filter(FilterBaseRequest request)
        {
            var collections = _collectionRepository.GetQueryable();
            collections = collections.Where(c => (string.IsNullOrEmpty(request.KeyWord) || c.Name.Contains(request.KeyWord) || c.NameEn!.Contains(request.KeyWord) || c.NameVi!.Contains(request.KeyWord)));
            var paged = await PagedResponse<Collection>.CreateAsync(collections, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<CollectionResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<List<CollectionResponse>>> GetAll()
        {
            var alls = await _collectionRepository.GetAllAsync();
            var response = _mapper.Map<List<CollectionResponse>>(alls);
            return ApiResponse<List<CollectionResponse>>.Success(response);
        }

        public async Task<ApiResponse<CollectionResponse>> GetById(Guid id)
        {
            var collection = await _collectionRepository.GetByIdAsync(id);
            if (collection == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<CollectionResponse>(collection);
            return ApiResponse<CollectionResponse>.Success(response);
        }

        public async Task<ApiResponse<List<CollectionResponse>>> GetDisplayShow()
        {
            var collections = await _collectionRepository.GetCollectionsShow();
            var response = _mapper.Map<List<CollectionResponse>>(collections);
            return ApiResponse<List<CollectionResponse>>.Success(response);
        }

        public async Task<ApiResponse<CollectionResponse>> Update(UpdateCollectionRequest request)
        {
            var collection = _mapper.Map<Collection>(request);
            collection.UpdatedDate = DateTime.Now;
            _collectionRepository.Update(collection);
            if (await _collectionRepository.SaveAsync())
            {
                return ApiResponse<CollectionResponse>.Success(Common.UpdateSuccess);
            }
            else
            {
                throw new BadRequestException(Common.UpdateFailure);
            }
        }
    }
}
