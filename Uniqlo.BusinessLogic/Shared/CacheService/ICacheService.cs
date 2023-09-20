using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.BusinessLogic.Shared.CacheService
{
    public interface ICacheService
    {
        Task<T?> GetAsync<T>(string cacheKey) where T : class;
        Task<T> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> factory) where T : class;
        Task SetAsync<T>(string cacheKey, T value, TimeSpan cacheDuration) where T : class;
        Task RemoveAsync(string cacheKey);
        Task RemoveByPrefixAsync(string prefixKey);
    }
}
