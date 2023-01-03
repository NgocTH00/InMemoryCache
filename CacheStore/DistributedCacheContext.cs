using MemoryCacheDemo.Controllers;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MemoryCacheDemo.CacheStore
{
    public class DistributedCacheContext
    {
        private readonly IDistributedCache _cache;
        private readonly ILogger<DistributedCacheContext> _logger;

        public DistributedCacheContext(IDistributedCache cache, ILogger<DistributedCacheContext> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        public void SaveToCache<TModel>(TModel data, params object[] arrs) where TModel : class
        {
            var keys = arrs.Cast<object>().Select(x => x.ToString());
            string key = typeof(TModel).Name + " - " + string.Join("-", keys);
            _logger.LogInformation(key);
            TransactionLogController.KEYS.Add(key);
            var json = JsonSerializer.Serialize(data);
            _cache.Set(key, Encoding.ASCII.GetBytes(json));
        }

        public TModel GetFromCache<TModel>(params object[] arrs) where TModel : class
        {
            var keys = arrs.Cast<object>().Select(x => x.ToString());
            string key = typeof(TModel).Name + " - " + string.Join("-", keys);
            var json = _cache.GetString(key);
            var data = JsonSerializer.Deserialize<TModel>(json);
            return data;
        }

        public TModel GetFromCache<TModel>(string key) where TModel : class
        {
            var json = _cache.GetString(key.ToString());
            var data = JsonSerializer.Deserialize<TModel>(json);
            return data;
        }
    }
}
