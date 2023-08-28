using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.Context;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.RequestModels.Product;

namespace Uniqlo.DataAccess.Repositories.Implements
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly UniqloContext _context;
        public ProductRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Product> FilterProducts(FilterProductRequest filter)
        {
            var products = from p in _context.Products
                           join pc in _context.ProductCategories on p.Id equals pc.ProductId
                           join ps in _context.ProductSizes on p.Id equals ps.ProductId
                           join pcl in _context.ProductColors on p.Id equals pcl.ProductId
                           where (filter.CategoryId == null || pc.CategoryId == filter.CategoryId)
                           && (filter.SizeIds == null || filter.SizeIds.Count() == 0 || filter.SizeIds.Contains(ps.SizeId))
                           && (filter.ColorIds == null || filter.ColorIds.Count() == 0 || filter.ColorIds.Contains(pcl.ColorId))
                           select p;

            Expression<Func<Product, bool>> predicate = s => s.DeleteStatus == false
            && (string.IsNullOrEmpty(filter.KeyWord) || s.Name.Contains(filter.KeyWord) || s.NameEn!.Contains(filter.KeyWord) || s.NameVi!.Contains(filter.KeyWord))
            && (filter.CollectionId == null || filter.CollectionId == s.CollectionId)
            && (filter.IsSale == null || s.IsSale == filter.IsSale)
            && (filter.IsOnlineOnly == null || s.IsOnlineOnly == filter.IsOnlineOnly)
            && (filter.IsLimited == null || s.IsLimited == filter.IsLimited);

            products = products.Where(predicate);

            return products;
        }

        public IQueryable<Product> GetProductsByCategory(Guid categoryId, Expression<Func<Product, bool>> predicate)
        {
            var products = _context.Products
                .Join(_context.ProductCategories, p => p.Id, pc => pc.ProductId, (p, pc) => new { p, pc })
                .Where(p => p.pc.CategoryId == categoryId)
                .Select(p => p.p);

            products = products.Where(predicate);

            return products;
        }

        public IQueryable<Product> SortProducts(IQueryable<Product> products, string sortBy)
        {
            switch (sortBy)
            {
                case "star_asc":
                    products = products.OrderBy(s => s.ProductReview!.Star);
                    break;
                case "star_desc":
                    products = products.OrderByDescending(s => s.ProductReview!.Star);
                    break;
                case "price_asc":
                    products = products.OrderBy(s => s.ProductPrice.Price);
                    break;
                case "price_desc":
                    products = products.OrderByDescending(s => s.ProductPrice.Price);
                    break;
                default:
                    products = products.OrderBy(s => s.CreatedDate);
                    break;
            }

            return products;
        }
    }
}
