using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.Core.Helpers;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.Context;
using Uniqlo.Models.EntityModels;

namespace Uniqlo.DataAccess.Repositories.Implements
{
    public class ProductDetailRepository : RepositoryBase<ProductDetail>, IProductDetailRepository
    {
        private readonly UniqloContext _context;
        public ProductDetailRepository(UniqloContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddProductDetails(Guid productId)
        {
            //var product = _context.Products.SingleOrDefault(p => p.Id == productId);
            var products = await _context.Products.ToListAsync();
            foreach (var product in products)
            {
                var productSizes = await _context.ProductSizes.Where(s => s.ProductId == product.Id).ToListAsync();
                var productColors = await _context.ProductColors.Where(s => s.ProductId == product.Id).ToListAsync();
                List<ProductDetail> productDetails = new List<ProductDetail>();
                foreach (var color in productColors)
                {
                    foreach (var size in productSizes)
                    {
                        ProductDetail productDetail = new ProductDetail
                        {
                            Id = Guid.NewGuid(),
                            SizeId = size.SizeId,
                            ColorId = color.ColorId,
                            ProductId = product.Id,
                            InStock = RandomGenerator.GenerateInteger(1, 10),
                        };
                        productDetails.Add(productDetail);
                    }
                }
                await _context.ProductDetails.AddRangeAsync(productDetails);
                await _context.SaveChangesAsync();
            }

            return true;
        }

        public async Task<List<ProductDetail>> GetProductDetailByProduct(Guid productId)
        {
            var productDetails = await _context.ProductDetails
                .Where(p => p.ProductId == productId)
                .ToListAsync();

            return productDetails;
        }
    }
}
