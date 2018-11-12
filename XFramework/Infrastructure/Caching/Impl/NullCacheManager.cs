namespace XFramework.Infrastructure.Caching.Impl
{
    public class NullCacheManager : CacheManagerBase
    {
        public override CacheValue<T> Get<T>(string key)
        {
            return CacheValue<T>.NoValue;
        }

        public override void Set<T>(string key, T data, int cacheTime)
        {
        }

        public override bool IsSet(string key)
        {
            return false;
        }

        public override void Remove(string key)
        {
        }

        public override void RemoveByPattern(string pattern)
        {
        }

        public override void Clear()
        {
        }
    }
}