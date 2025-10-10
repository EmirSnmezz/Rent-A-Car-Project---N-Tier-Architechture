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
    }
}
