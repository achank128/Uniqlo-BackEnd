using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Collection;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CollectionService
{
    public interface ICollectionService
    {
        Task<ApiResponse<CollectionResponse>> Create(CreateCollectionRequest request);
        Task<ApiResponse<CollectionResponse>> CreateFull(CreateCollectionFullRequest request);
        Task<PagedResponse<CollectionResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<CollectionResponse>>> GetAll();
        Task<ApiResponse<List<CollectionResponse>>> GetDisplayShow();
        Task<ApiResponse<CollectionResponse>> GetById(Guid id);
        Task<ApiResponse<CollectionResponse>> Update(UpdateCollectionRequest request);
        Task<ApiResponse<CollectionResponse>> Delete(Guid id);
    }
}
