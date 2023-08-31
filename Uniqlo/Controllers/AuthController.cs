using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Uniqlo.BusinessLogic.Services.AuthService;
using Uniqlo.Models.RequestModels.User;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Đăng ký tài khoản
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            var response = await _authService.Register(request);
            return Ok(response);
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            var response = await _authService.Login(request);
            return Ok(response);
        }
    }
}
