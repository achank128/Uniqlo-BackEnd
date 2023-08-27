using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Collection;
using Uniqlo.Models.RequestModels.Unit;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.Interfaces
{
    public interface ICollectionsService
    {
        Task<ApiResponse<CollectionResponse>> Create(CreateCollectionRequest request);
        Task<PagedResponse<CollectionResponse>> GetAll(FilterBaseRequest request);
        Task<ApiResponse<CollectionResponse>> GetById(Guid id);
        Task<ApiResponse<CollectionResponse>> Update(UpdateCollectionRequest request);
        Task<ApiResponse<CollectionResponse>> Delete(Guid id);
    }
}
