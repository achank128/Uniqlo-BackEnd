using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Security.Claims;
using Uniqlo.BusinessLogic.Services.UserService;
using Uniqlo.Models.Models;

namespace Uniqlo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _userService.GetAll();
            return Ok(response);
        }

        [HttpPost("filter")]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> Filter(FilterBaseRequest request)
        {
            var response = await _userService.Filter(request);
            return Ok(response);
        }

        [HttpGet("getme")]
        [Authorize]
        public async Task<IActionResult> GetMe()
        {
            Guid userId = new Guid(User.FindFirstValue(ClaimTypes.Sid));
            var response = await _userService.GetById(userId);
            return Ok(response);
        }


    }
}
