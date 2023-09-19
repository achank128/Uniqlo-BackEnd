using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.Category;
using Uniqlo.Models.RequestModels.UserAddress;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.UserAddressService
{
    public interface IUserAddressService
    {
        Task<ApiResponse<UserAddressResponse>> Create(CreateUserAddressRequest request);
        Task<PagedResponse<UserAddressResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<UserAddressResponse>>> GetAll();
        Task<ApiResponse<List<UserAddressResponse>>> GetByUser(Guid userId);
        Task<ApiResponse<UserAddressResponse>> GetById(Guid id);
        Task<ApiResponse<UserAddressResponse>> Update(UpdateUserAddressRequest request);
        Task<ApiResponse<UserAddressResponse>> SetDefault(Guid id, Guid userId);
        Task<ApiResponse<UserAddressResponse>> Delete(Guid id);
    }
}
