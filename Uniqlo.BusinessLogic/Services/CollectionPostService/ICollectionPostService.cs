using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.CollectionPost;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CollectionPostService
{
    public interface ICollectionPostService
    {
        Task<ApiResponse<CollectionPostResponse>> Create(CreateCollectionPostRequest request);
        Task<ApiResponse<CollectionPostResponse>> Upload(UploadCollectionPostRequest request);
        Task<PagedResponse<CollectionPostResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<CollectionPostResponse>>> GetAll();
        Task<ApiResponse<CollectionPostResponse>> GetById(Guid id);
        Task<ApiResponse<CollectionPostResponse>> Update(UpdateCollectionPostRequest request);
        Task<ApiResponse<CollectionPostResponse>> Delete(Guid id);
    }
}
