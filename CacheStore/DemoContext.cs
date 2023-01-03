using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace MemoryCacheDemo.CacheStore
{
    public class CacheContext
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<CacheContext> _logger;
        private readonly MemoryCacheEntryOptions _option;

        public CacheContext(IMemoryCache cache, ILogger<CacheContext> logger)
        {
            _cache = cache;
            _logger = logger;
            var expired = new DateTime(DateTime.Now.Year, 5, 26, 16, 38, 0);
            _option = new MemoryCacheEntryOptions()
            {
                AbsoluteExpiration = new DateTimeOffset(expired)
            };
        }

        /// <summary>
        /// Kiểm tra xem key có được sử dụng hay không
        /// </summary>
        /// <typeparam name="TData">Type cửa value mà key referrence đến</typeparam>
        /// <param name="arrkeys"></param>
        /// <returns></returns>
        public bool CheckIfExist<TData>(params string[] arrkeys)
        {
            string key = string.Join("-", arrkeys.Append(typeof(TData).Name).OrderBy(x => x));
            return _cache.TryGetValue(key, out TData data);
        }

        /// <summary>
        /// Lưu data vào Cache với key 
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="data"></param>
        /// <param name="arrkeys"></param>
        /// <returns></returns>
        public bool Save<TData>(TData data, params string[] arrkeys)
        {
            try
            {
                string key = string.Join("-", arrkeys.Append(typeof(TData).Name).OrderBy(x => x));
                _cache.Set(key, data, _option);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Lấy data từ cache bằng key
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="arrkeys"></param>
        /// <returns></returns>
        public TData Get<TData>(params string[] arrkeys)
        {
            string key = string.Join("-", arrkeys.Append(typeof(TData).Name).OrderBy(x => x));
            return _cache.Get<TData>(key);
        }
    }
}
