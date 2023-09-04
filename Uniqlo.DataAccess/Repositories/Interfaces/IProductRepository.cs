using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.RequestModels.Product;

namespace Uniqlo.DataAccess.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        void CreateCrawl(Product product, CreateProductCrawlRequest productCrawl);
        Task<Product> GetProductById(Guid id);
        IQueryable<Product> GetProductsByCategory(Guid categoryId, Expression<Func<Product, bool>> predicate);
        IQueryable<Product> FilterProducts(FilterProductRequest filter);
        IQueryable<Product> SortProducts(IQueryable<Product> products, string sortBy);
    }
}
