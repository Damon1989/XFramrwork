using System.Threading.Tasks;

namespace XFramework.Infrastructure.Caching.Impl
{
    public abstract class CacheManagerBase : ICacheManager
    {
        public abstract CacheValue<T> Get<T>(string key);

        public Task<CacheValue<T>> GetAsync<T>(string key)
        {
            return Task.FromResult(Get<T>(key));
        }

        public abstract void Set<T>(string key, T data, int cacheTime);

        public Task SetAsync<T>(string key, T data, int cacheTime)
        {
            return Task.Run(() => Set(key, data, cacheTime));
        }

        public abstract bool IsSet(string key);

        public Task<bool> IsSetAsync(string key)
        {
            return Task.FromResult(IsSet(key));
        }

        public abstract void Remove(string key);

        public Task RemoveAsync(string key)
        {
            return Task.Run(() => RemoveAsync(key));
        }

        public abstract void RemoveByPattern(string pattern);

        public Task RemoveByPatternAsync(string pattern)
        {
            return Task.Run(() => RemoveByPattern(pattern));
        }

        public abstract void Clear();

        public Task ClearAsync()
        {
            return Task.Run(() => Clear());
        }
    }
}