using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.Models;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.UserService
{
    public interface IUserService
    {
        Task<PagedResponse<UserResponse>> Filter(FilterBaseRequest request);
        Task<ApiResponse<List<UserResponse>>> GetAll();
        Task<ApiResponse<UserResponse>> GetById(Guid id);
    }
}
