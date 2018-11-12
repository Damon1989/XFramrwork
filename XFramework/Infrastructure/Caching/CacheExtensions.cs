using System;
using System.Threading.Tasks;

namespace XFramework.Infrastructure.Caching
{
    public static class CacheExtensions
    {
        public static CacheValue<T> Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        public static CacheValue<T> Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            if (cacheTime <= 0)
            {
                return new CacheValue<T>(acquire(), true);
            }

            var cacheValue = cacheManager.Get<T>(key);
            if (cacheValue.HasValue) return cacheValue;

            cacheValue = new CacheValue<T>(acquire(), true);
            cacheManager.Set(key, cacheValue.Value, cacheTime);

            return cacheValue;
        }

        public static Task<CacheValue<T>> GetAsync<T>(this ICacheManager cacheManager,
                                                      string key,
                                                      Func<Task<T>> acquire,
                                                      bool continueOnCapturedContext = false)
        {
            return cacheManager.GetAsync(key, 60, acquire, continueOnCapturedContext);
        }

        public static async Task<CacheValue<T>> GetAsync<T>(this ICacheManager cacheManager,
            string key,
            int cacheTime,
            Func<Task<T>> acquire,
            bool continueOnCapturedContext = false)
        {
            if (cacheTime <= 0)
            {
                return new CacheValue<T>(await acquire().ConfigureAwait(continueOnCapturedContext), true);
            }

            var cacheValue = await cacheManager.GetAsync<T>(key)
                                               .ConfigureAwait(continueOnCapturedContext);
            if (cacheValue.HasValue) return cacheValue;

            cacheValue = new CacheValue<T>(await acquire().ConfigureAwait(continueOnCapturedContext), true);
            await cacheManager.SetAsync(key, cacheValue.Value, cacheTime)
                .ConfigureAwait(continueOnCapturedContext);
            return cacheValue;
        }

        public static Task<CacheValue<T>> GetAsync<T>(this ICacheManager cacheManager,
            string key,
            Func<T> acquire,
            bool continueOnCapturedContext = false)
        {
            return cacheManager.GetAsync<T>(key, 60, acquire, continueOnCapturedContext);
        }

        public static async Task<CacheValue<T>> GetAsync<T>(this ICacheManager cacheManager,
                                                            string key,
                                                            int cacheTime,
                                                            Func<T> acquire,
                                                            bool continueOnCapturedContext = false)
        {
            if (cacheTime <= 0)
            {
                return new CacheValue<T>(acquire(), true);
            }

            var cacheValue = await cacheManager.GetAsync<T>(key)
                .ConfigureAwait(continueOnCapturedContext);
            if (cacheValue.HasValue) return cacheValue;

            cacheValue = new CacheValue<T>(acquire(), true);
            await cacheManager.SetAsync(key, cacheValue.Value, cacheTime)
                .ConfigureAwait(continueOnCapturedContext);
            return cacheValue;
        }
    }
}