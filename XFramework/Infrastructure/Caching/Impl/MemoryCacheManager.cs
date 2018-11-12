using System;
using Microsoft.Extensions.Caching.Memory;

namespace XFramework.Infrastructure.Caching.Impl
{
    public class MemoryCacheManager : CacheManagerBase
    {
        protected MemoryCache Cache = new MemoryCache(new MemoryCacheOptions());

        public override CacheValue<T> Get<T>(string key)
        {
            return Cache.Get<CacheValue<T>>(key) ?? CacheValue<T>.NoValue;
        }

        public override void Set<T>(string key, T data, int cacheTime)
        {
            Cache.Set(key,
                      new CacheValue<T>(data, true),
                      DateTime.Now + TimeSpan.FromMinutes(cacheTime));
        }

        public override bool IsSet(string key)
        {
            return Cache.TryGetValue(key, out var result);
        }

        public override void Remove(string key)
        {
            Cache.Remove(key);
        }

        public override void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }

        public override void Clear()
        {
            throw new NotImplementedException();
        }
    }
}