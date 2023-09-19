using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Uniqlo.BusinessLogic.Exceptions;
using Uniqlo.Core.Helpers;
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

        public void CreateCrawl(Product product, CreateProductCrawlRequest productCrawl)
        {
            //Add gender type id
            var genderType = _context.GenderTypes.Where(s => s.Name == productCrawl.For).SingleOrDefault();
            if (genderType == null)
            {
                throw new BadRequestException("Product not have gender type");
            }
            product.GenderTypeId = genderType.Id;

            //Add product price
            ProductPrice productPrice = new ProductPrice
            {
                Id = Guid.NewGuid(),
                Price = productCrawl.Price,
                PromoPrice = productCrawl.PromoPrice,
                ImportPrice = productCrawl.ImportPrice,
                VAT = productCrawl.VAT,
            };
            _context.ProductPrices.Add(productPrice);
            product.ProductPriceId = productPrice.Id;

            //Add product review
            ProductReview productReview = new ProductReview
            {
                Id = Guid.NewGuid(),
                Star = productCrawl.Star,
                Amount = productCrawl.Amount,
            };
            _context.ProductReviews.Add(productReview);
            product.ProductReviewId = productReview.Id;


            //Add product image
            foreach (var imageUrl in productCrawl.ImageList)
            {
                ProductImage productSize = new ProductImage
                {
                    Id = Guid.NewGuid(),
                    ProductId = product.Id,
                    Image = "",
                    ImageUrl = imageUrl
                };
                _context.ProductImages.Add(productSize);
            }

            //Add product color
            List<Color> colorList = new List<Color>();
            foreach (var colorName in productCrawl.ColorList)
            {
                var color = _context.Colors.FirstOrDefault(c => c.Name == colorName);
                if (color != null)
                {
                    ProductColor productColor = new ProductColor
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        ColorId = color.Id,
                    };
                    _context.ProductColors.Add(productColor);
                    colorList.Add(color);
                }
            }

            //Add product size
            List<Size> sizeList = new List<Size>();
            foreach (var sizeName in productCrawl.SizeList)
            {
                var size = _context.Sizes.FirstOrDefault(s => s.Name == sizeName && s.GenderTypeId == genderType.Id);
                if (size != null)
                {
                    ProductSize productSize = new ProductSize
                    {
                        Id = Guid.NewGuid(),
                        ProductId = product.Id,
                        SizeId = size.Id,
                    };
                    _context.ProductSizes.Add(productSize);
                }
            }

            //Add product details
            foreach (var color in colorList)
            {
                foreach (var size in sizeList)
                {
                    ProductDetail productDetail = new ProductDetail
                    {
                        Id = Guid.NewGuid(),
                        SizeId = size.Id,
                        ColorId = color.Id,
                        ProductId = product.Id,
                        InStock = RandomGenerator.GenerateInteger(1, 10),
                    };
                    _context.ProductDetails.Add(productDetail);
                }
            }

            //Add product collections
            product.CollectionId = new Guid("b986bff5-5e3a-43b4-d5b7-08dba6b03e8a");
            //Add product categories
            var categories = _context.Categories.Where(c => c.GenderTypeId == genderType.Id).ToList();
            var category = categories.ElementAt(RandomGenerator.GenerateInteger(0, categories.Count() - 1));
            ProductCategory productCategory = new ProductCategory
            {
                Id = Guid.NewGuid(),
                ProductId = product.Id,
                CategoryId = category.Id,
            };
            _context.ProductCategories.Add(productCategory);

            _context.Products.Add(product);
        }

        public IQueryable<Product> FilterProducts(FilterProductRequest filter)
        {
            var products = (from p in _context.Products
                            join pc in _context.ProductCategories on p.Id equals pc.ProductId into p_pcLeftJoin
                            from p_pc in p_pcLeftJoin.DefaultIfEmpty()
                            join ps in _context.ProductSizes on p.Id equals ps.ProductId into p_psLeftJoin
                            from p_ps in p_psLeftJoin.DefaultIfEmpty()
                            join pcl in _context.ProductColors on p.Id equals pcl.ProductId into p_pclLeftJoin
                            from p_pcl in p_pclLeftJoin.DefaultIfEmpty()
                            join pp in _context.ProductPrices on p.ProductPriceId equals pp.Id
                            where p.DeleteStatus == false
                            && (filter.CategoryId == null || p_pc.CategoryId == filter.CategoryId)
                            && (filter.SizeIds == null || filter.SizeIds.Count() == 0 || filter.SizeIds.Contains(p_ps.SizeId))
                            && (filter.ColorIds == null || filter.ColorIds.Count() == 0 || filter.ColorIds.Contains(p_pcl.ColorId))
                            && (string.IsNullOrEmpty(filter.KeyWord) || p.Name.Contains(filter.KeyWord) || p.NameEn!.Contains(filter.KeyWord) || p.NameVi!.Contains(filter.KeyWord))
                            && (filter.CollectionId == null || filter.CollectionId == p.CollectionId)
                            && (filter.GenderTypeId == null || filter.GenderTypeId == p.GenderTypeId)
                            && (filter.PriceMin == null || pp.Price >= filter.PriceMin)
                            && (filter.PriceMax == null || pp.Price <= filter.PriceMax)
                            && (filter.IsSale == null || p.IsSale == filter.IsSale)
                            && (filter.IsOnlineOnly == null || p.IsOnlineOnly == filter.IsOnlineOnly)
                            && (filter.IsLimited == null || p.IsLimited == filter.IsLimited)
                            select p).Distinct();
            //select new Product
            //{
            //    Id = p.Id,
            //    Name = p.Name,
            //    NameEn = p.NameEn,
            //    NameVi = p.NameVi,
            //    Description = p.Description,
            //    DescriptionEn = p.DescriptionEn,
            //    DescriptionVi = p.DescriptionVi,
            //    Overview = p.Overview,
            //    OverviewEn = p.OverviewEn,
            //    OverviewVi = p.OverviewVi,
            //    Materials = p.Materials,
            //    MaterialsEn = p.MaterialsEn,
            //    MaterialsVi = p.MaterialsVi,
            //    IsSale = p.IsSale,
            //    IsOnlineOnly = p.IsOnlineOnly,
            //    IsLimited = p.IsLimited,
            //    UnitId = p.UnitId,
            //    GenderTypeId = p.GenderTypeId,
            //    ProductPriceId = p.ProductPriceId,
            //    ProductReviewId = p.ProductReviewId,
            //    CollectionId = p.CollectionId,
            //    DeleteStatus = p.DeleteStatus,
            //    Status = p.Status,
            //    CreatedDate = p.CreatedDate,
            //    UpdatedDate = p.UpdatedDate,
            //};
            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            products.Include(p => p.ProductPrice).Load();
            products.Include(p => p.GenderType).Load();
            products.Include(p => p.ProductReview).Load();
            products.Include(p => p.ProductImages).Load();
            products.Include(p => p.ProductSizes).Load();
            products.Include(p => p.ProductColors).Load();

            return products;
        }

        public async Task<Product> GetProductById(Guid id)
        {
            var product = _context.Products.Where(p => p.Id == id);

            _context.ChangeTracker.LazyLoadingEnabled = false;
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
            product.Include(p => p.Collection).Load();
            product.Include(p => p.ProductPrice).Load();
            product.Include(p => p.ProductReview).Load();
            product.Include(p => p.GenderType).Load();
            product.Include(p => p.ProductImages).Load();
            product.Include(p => p.ProductSizes).ThenInclude(pc => pc.Size).Load();
            product.Include(p => p.ProductColors).ThenInclude(pc => pc.Color).Load();
            
            return await product.SingleOrDefaultAsync();
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
                case "created_date_asc":
                    products = products.OrderBy(s => s.CreatedDate);
                    break;
                case "created_date_desc":
                    products = products.OrderByDescending(s => s.CreatedDate);
                    break;
                case "name_asc":
                    products = products.OrderBy(s => s.Name);
                    break;
                case "name_desc":
                    products = products.OrderByDescending(s => s.Name);
                    break;
                default:
                    products = products.OrderBy(s => s.Id);
                    break;
            }

            return products;
        }
    }
}
