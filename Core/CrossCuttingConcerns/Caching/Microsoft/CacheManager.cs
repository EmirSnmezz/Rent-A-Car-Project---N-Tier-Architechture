using System.Text.RegularExpressions;
using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class CacheManager : ICacheService
    {
        IMemoryCache _caching;

        public CacheManager()
        {
            _caching = ServiceTool.ServiceProvider.GetService<IMemoryCache>();
        }
        public void Add(string key, object value, int duration)
        {
            _caching.Set(key, value, TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            return _caching.Get<T>(key);
        }

        public object Get(string key)
        {
            return _caching.Get(key);
        }

        public bool IsAdd(string key)
        {
            return _caching.TryGetValue(key, out _);
        }

        public void Remove(string key)
        {
            _caching.Remove(key);
        }

        public void RemoveByPattern(string pattern)
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_caching) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();

            foreach(var cacheItem in cacheEntriesCollection)
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = cacheCollectionValues.Where(cache => regex.IsMatch(cache.Key.ToString())).Select(d => d.Key).ToList();

            foreach(var key in keysToRemove)
            {
                _caching.Remove(key);
            }
        }
    }
}
