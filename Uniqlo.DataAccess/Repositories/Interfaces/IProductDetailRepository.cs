using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.RequestModels.ProductDetail;

namespace Uniqlo.DataAccess.Repositories.Interfaces
{
    public interface IProductDetailRepository : IRepositoryBase<ProductDetail>
    {
        Task<bool> AddProductDetails(Guid productId);
        IQueryable<ProductDetail> FilterProducts(Expression<Func<ProductDetail, bool>> condition);
        Task<List<ProductDetail>> GetProductDetailByProduct(Guid productId);

    }
}
