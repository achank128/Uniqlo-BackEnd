using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.WishListService
{
    public interface IWishListService
    {
        Task<ApiResponse<WishListResponse>> AddWishList(Guid userId, Guid productId);
        Task<ApiResponse<List<WishListResponse>>> GetUserWishList(Guid userId);
        Task<PagedResponse<WishListResponse>> GetAll(FilterBaseRequest request);
        Task<ApiResponse<WishListResponse>> Delete(Guid id);

    }
}
