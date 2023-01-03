using MemoryCacheDemo.Models;
using Microsoft.Extensions.Caching.Memory;
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
    public class MemoryCacheContext
    {
        private readonly IMemoryCache _cache;
        private readonly ILogger<MemoryCacheContext> _logger;

        public MemoryCacheContext(IMemoryCache cache, ILogger<MemoryCacheContext> logger)
        {
            _cache = cache;
            _logger = logger;
        }

        /// <summary>
        /// Lấy toàn bộ record trong cache của TModel
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <returns></returns>
        public IEnumerable<TModel> GetDatas<TModel>() where TModel : class
        {
            var start = DateTime.Now;
            List<TModel> messages = new();
            var keys = GetCacheKeys(typeof(TModel));
            foreach(var item in keys)
            {
                var byteArr = _cache.Get(item) as byte[];
                var json = Encoding.ASCII.GetString(byteArr);
                var data = JsonSerializer.Deserialize<TModel>(json);
                messages.Add(data);
            }
            _logger.LogInformation($"Start at: {start}. Cost: {DateTime.Now.Subtract(start).TotalMilliseconds}. End: {DateTime.Now}");
            return messages;
        }

        /// <summary>
        /// Lưu mỗi record vào cache với 1 key riêng
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="data"></param>
        /// <param name="keyIndex"></param>
        public void AddData<TModel>(TModel data, string[] keyIndex) where TModel : class
        {
            var start = DateTime.Now;
            string key = typeof(TModel).Name+ " - " + string.Join("-",keyIndex);
            var json = JsonSerializer.Serialize(data);
            _cache.Set<byte[]>(key, Encoding.ASCII.GetBytes(json));
            _logger.LogInformation($"Start at: {start}. Cost: {DateTime.Now.Subtract(start).TotalMilliseconds}. End: {DateTime.Now}");
        }

        /// <summary>
        /// Lấy ra 1 record từ Cache bằng keyIndex
        /// </summary>
        /// <typeparam name="TModel"></typeparam>
        /// <param name="keyIndex"></param>
        /// <returns></returns>
        public TModel GetData<TModel>(string[] keyIndex) where TModel : class
        {
            string key = typeof(TModel).Name+ " - " + string.Join("-", keyIndex);
            var byteArr = _cache.Get(key) as byte[];
            var json = Encoding.ASCII.GetString(byteArr);
            var data = JsonSerializer.Deserialize<TModel>(json);
            return data;
        }

        /// <summary>
        /// Get toàn bộ key của kiểu truyền vào
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public List<string> GetCacheKeys(Type type)
        {
            var field = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance);
            var collection = field.GetValue(_cache) as ICollection;
            var items = new List<string>();
            if (collection != null)
                foreach (var item in collection)
                {
                    var methodInfo = item.GetType().GetProperty("Key");
                    var val = methodInfo.GetValue(item);
                    if (val.ToString().Contains(type.Name))
                    {
                        items.Add(val.ToString());
                    }
                }
            return items;
        }
    }
}
