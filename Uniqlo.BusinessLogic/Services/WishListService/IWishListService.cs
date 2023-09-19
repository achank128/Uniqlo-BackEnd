using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.WishList;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.WishListService
{
    public interface IWishListService
    {
        Task<ApiResponse<WishListResponse>> Create(CreateWishListRequest request);
        Task<PagedResponse<WishListResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<WishListResponse>>> GetAll();
        Task<ApiResponse<List<WishListResponse>>> GetUserWishList(Guid userId);
        Task<ApiResponse<WishListResponse>> Delete(Guid id);

    }
}
