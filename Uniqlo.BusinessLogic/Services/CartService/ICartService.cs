using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels;
using Uniqlo.Models.RequestModels.Cart;
using Uniqlo.Models.RequestModels.Category;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.CartService
{
    public interface ICartService
    {
        Task<ApiResponse<CartResponse>> Create(CreateCartRequest request);
        Task<PagedResponse<CartResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<CartResponse>>> GetAll();
        Task<ApiResponse<CartResponse>> GetById(Guid id);
        Task<ApiResponse<CartResponse>> GetByUser();
        Task<ApiResponse<CartResponse>> Update(UpdateCartRequest request);
        Task<ApiResponse<CartResponse>> Delete(Guid id, DeleteRequest request);
    }
}
