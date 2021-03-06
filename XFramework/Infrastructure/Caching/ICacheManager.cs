﻿using System.Threading.Tasks;

namespace XFramework.Infrastructure.Caching
{
    public interface ICacheManager
    {
        CacheValue<T> Get<T>(string key);

        Task<CacheValue<T>> GetAsync<T>(string key);

        void Set<T>(string key, T data, int cacheTime);

        Task SetAsync<T>(string key, T data, int cacheTime);

        bool IsSet(string key);

        Task<bool> IsSetAsync(string key);

        void Remove(string key);

        Task RemoveAsync(string key);

        void RemoveByPattern(string pattern);

        Task RemoveByPatternAsync(string pattern);

        void Clear();

        Task ClearAsync();
    }
}