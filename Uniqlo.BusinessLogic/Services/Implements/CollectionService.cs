using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.BusinessLogic.Services.Interfaces;
using Uniqlo.Core.Keywords;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Collection;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.Implements
{
    public class CollectionService : ICollectionService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<Collection> _collectionRepository;

        public CollectionService(IRepositoryBase<Collection> collectionRepository, IMapper mapper)
        {
            _collectionRepository = collectionRepository;
            _mapper = mapper;
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

        public async Task<PagedResponse<CollectionResponse>> GetAll(FilterBaseRequest request)
        {
            var collections = _collectionRepository.GetQueryable();
            var paged = await PagedResponse<Collection>.CreateAsync(collections, request.PageIndex, request.PageSize);
            var response = _mapper.Map<PagedResponse<CollectionResponse>>(paged);
            return response;
        }

        public async Task<ApiResponse<CollectionResponse>> GetById(Guid id)
        {
            var collection = await _collectionRepository.GetByIdAsync(id);
            if (collection == null) throw new NotFoundException(Common.NotFound);

            var response = _mapper.Map<CollectionResponse>(collection);
            return ApiResponse<CollectionResponse>.Success(response);
        }

        public async Task<ApiResponse<CollectionResponse>> Update(UpdateCollectionRequest request)
        {
            var collection = _mapper.Map<Collection>(request);
            collection.UpdatedDate= DateTime.Now;
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
