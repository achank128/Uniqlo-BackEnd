using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Models.Models;
using Uniqlo.Models.RequestModels.User;
using Uniqlo.Models.ResponseModels;

namespace Uniqlo.BusinessLogic.Services.AuthService
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponse>> Register(UserRegisterRequest request);
        Task<ApiResponse<AuthResponse>> Login(UserLoginRequest request);
        Task<string> GenerateToken(UserResponse user);

    }
}
