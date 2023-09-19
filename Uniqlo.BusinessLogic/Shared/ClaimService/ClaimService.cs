using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.BusinessLogic.Shared.ClaimService
{
    public class ClaimService : IClaimService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ClaimService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }


        public string GetUserInfo(string info)
        {
            return GetClaim(info);
        }

        public Guid GetUserId()
        {
            Guid id = new Guid(GetClaim(ClaimTypes.Sid));
            return id;
        }

        public string GetUserEmail()
        {
            var email = GetClaim("emailaddress");
            if (email == null) return "";
            return email;
        }

        public string GetClaim(string key)
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(key)?.Value;
        }
    }
}
