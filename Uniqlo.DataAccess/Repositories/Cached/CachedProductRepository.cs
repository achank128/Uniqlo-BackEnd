using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Uniqlo.DataAccess.Repositories.Interfaces;
using Uniqlo.DataAccess.RepositoryBase;
using Uniqlo.Models.Context;
using Uniqlo.Models.EntityModels;
using Uniqlo.Models.RequestModels.Product;

namespace Uniqlo.DataAccess.Repositories.Cached
{
    public class CachedProductRepository : RepositoryBase<Product>, IProductRepository
    {
        private readonly IProductRepository _decorated;
        private readonly IMemoryCache _memoryCache;
        private readonly IDistributedCache _distributedCache;

        public CachedProductRepository(UniqloContext context, IProductRepository decorated, IMemoryCache memoryCache, IDistributedCache distributedCache) : base(context)
        {
            _decorated = decorated;
            _memoryCache = memoryCache;
            _distributedCache = distributedCache;
        }

        public void CreateCrawl(Product product, CreateProductCrawlRequest productCrawl) => _decorated.CreateCrawl(product, productCrawl);

        public IQueryable<Product> FilterProducts(FilterProductRequest filter)
        {
            return _decorated.FilterProducts(filter);
        }

        public async Task<Product> GetProductById(Guid id)
        {
            string key = $"product-{id}";
            return await _memoryCache.GetOrCreateAsync(key, entry =>
            {
                entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(2));
                return _decorated.GetProductById(id);
            });

            //string? cachedProduct = await _distributedCache.GetStringAsync(key);
            //Product? product;
            //if(string.IsNullOrEmpty(cachedProduct))
            //{
            //    product = await _decorated.GetProductById(id);
            //    if(product == null)
            //    {
            //        return product;
            //    }
            //    //await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(product));

            //    var options = new DistributedCacheEntryOptions()
            //    .SetSlidingExpiration(TimeSpan.FromSeconds(60));
            //    string cacheValue = JsonConvert.SerializeObject(product);
            //    await _distributedCache.SetAsync(key, Encoding.UTF8.GetBytes(cacheValue), options);
            //    return product;
            //}
            //product = JsonConvert.DeserializeObject<Product>(
            //    cachedProduct,
            //    new JsonSerializerSettings
            //    {
            //        ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor
            //    });
            //return product;
        }

        public IQueryable<Product> GetProductsByCategory(Guid categoryId, Expression<Func<Product, bool>> predicate)
        {
            return _decorated.GetProductsByCategory(categoryId, predicate);
        }

        public IQueryable<Product> SortProducts(IQueryable<Product> products, string sortBy)
        {
            return _decorated.SortProducts(products, sortBy);
        }
    }
}
