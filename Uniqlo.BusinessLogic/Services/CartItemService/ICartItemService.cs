using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.ResponseModels;
using Uniqlo.Models.RequestModels.CartItem;

namespace Uniqlo.BusinessLogic.Services.CartItemService
{
    public interface ICartItemService
    {
        Task<ApiResponse<CartItemResponse>> Create(CreateCartItemRequest request);
        Task<PagedResponse<CartItemResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<CartItemResponse>>> GetAll();
        Task<ApiResponse<CartItemResponse>> GetById(Guid id);
        Task<ApiResponse<CartItemResponse>> Update(UpdateCartItemRequest request);
        Task<ApiResponse<CartItemResponse>> Delete(Guid id);
    }
}
