using Castle.Components.DictionaryAdapter;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        void Add(string key, object value, int duration);
        T Get<T>(string key);
        object Get(string key);
        bool isAdd(string key);
        void Remove(string key);
        void RemoveByPatter(string pattern);
    }
}
