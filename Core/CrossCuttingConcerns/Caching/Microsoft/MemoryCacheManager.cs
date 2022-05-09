using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public void Add(string key, object value, int duration)
        {
            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public bool Contains(string key)
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public T Get<T>(string key)
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollection = typeof(MemoryCache).GetProperty("EntriesCollection", BindingFlags.NonPublic | BindingFlags.Instance)?
                                                            .GetValue(_memoryCache) as dynamic ?? throw new Exception();
            var cacheCollectionKeys = new List<string>();

            foreach (var cacheItem in cacheEntriesCollection)
            {
                string key = cacheItem.GetType().GetProperty("Key").GetValue(cacheItem);
                cacheCollectionKeys.Add(key);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionKeys.Where(key => regex.IsMatch(key));

            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
        }

    }
}

