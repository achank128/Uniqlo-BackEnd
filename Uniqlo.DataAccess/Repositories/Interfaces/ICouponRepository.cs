using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.RequestModels.Product;

namespace Uniqlo.DataAccess.Repositories.Interfaces
{
    public interface ICouponRepository : IRepositoryBase<Coupon>
    {
        Task<List<Coupon>> GetCouponsByUser(Guid userId);
    }
}
