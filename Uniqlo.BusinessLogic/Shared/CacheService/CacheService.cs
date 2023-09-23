using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uniqlo.BusinessLogic.Shared.CacheService
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _distributedCache;
        private static readonly ConcurrentDictionary<string, bool> CacheKeys = new();

        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T?> GetAsync<T>(string cacheKey) where T : class
        {
            string? cachedValue = await _distributedCache.GetStringAsync(cacheKey);
            if (cachedValue == null)
            {
                return null;
            }
            T? result = JsonConvert.DeserializeObject<T>(cachedValue);
            return result;
        }

        public async Task<string> GetStringAsync(string cacheKey)
        {
            string? cachedValue = await _distributedCache.GetStringAsync(cacheKey);
            if (string.IsNullOrEmpty(cachedValue))
            {
                return null;
            }
            return cachedValue;
        }

        public async Task<T?> GetOrSetAsync<T>(string cacheKey, Func<Task<T>> factory) where T : class
        {
            T? cachedValue = await GetAsync<T>(cacheKey);
            if (cachedValue != null)
            {
                return cachedValue;
            }
            cachedValue = await factory();
            await SetAsync(cacheKey, cachedValue, TimeSpan.FromSeconds(60));
            return cachedValue;
        }

        public async Task SetAsync<T>(string cacheKey, T value, TimeSpan cacheDuration) where T : class
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = cacheDuration,
                SlidingExpiration = cacheDuration
            };
            string cacheValue = JsonConvert.SerializeObject(value);
            await _distributedCache.SetStringAsync(cacheKey, cacheValue, options);
            //await _distributedCache.SetStringAsync(cacheKey, cacheValue);
            CacheKeys.TryAdd(cacheKey, false);
        }

        public async Task RemoveAsync(string cacheKey)
        {
            await _distributedCache.RemoveAsync(cacheKey);
            CacheKeys.TryRemove(cacheKey, out bool _);
        }

        public async Task RemoveByPrefixAsync(string prefixKey)
        {
            //foreach (var key in CacheKeys.Keys)
            //{
            //    if (key.StartsWith(prefixKey))
            //    {
            //        await RemoveAsync(key);
            //    }
            //}

            IEnumerable<Task> task = CacheKeys.Keys
                .Where(x => x.StartsWith(prefixKey))
                .Select(k => RemoveAsync(k));
            await Task.WhenAll(task);
        }

        public async Task SetStringAsync<T>(string cacheKey, T value, TimeSpan cacheDuration) where T : class
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = cacheDuration,
                SlidingExpiration = cacheDuration
            };
            string cacheValue = JsonConvert.SerializeObject(value, new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
            await _distributedCache.SetStringAsync(cacheKey, cacheValue, options);
            CacheKeys.TryAdd(cacheKey, false);
        }
    }
}
