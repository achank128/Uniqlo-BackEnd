using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.BusinessLogic.Shared.ClaimService
{
    public interface IClaimService
    {
        string GetUserInfo(string info);
        Guid GetUserId();
        string GetUserEmail();
        string GetClaim(string key);
    }
}
