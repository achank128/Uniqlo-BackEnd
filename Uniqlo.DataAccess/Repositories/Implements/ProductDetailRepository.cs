using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.Context;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.DataAccess.Repositories.Implements
{
    public class ProductDetailRepository : RepositoryBase<ProductDetail>, IProductDetailRepository
    {
        public ProductDetailRepository(UniqloContext context) : base(context)
        {
        }
    }
}
