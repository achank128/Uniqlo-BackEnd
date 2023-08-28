using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.Models.ResponseModels
{
    public class AuthResponse
    {
        public string AccessToken { get; set; }
        public UserResponse User { get; set; }
    }
}
