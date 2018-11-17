using System.Collections.Generic;

namespace XFramework.Infrastructure
{
    public static class DictionaryExtensions
    {
        public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        {
            return dictionary.TryGetValue(key, default(TValue));
        }

        public static TValue TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
        {
            var result = defaultValue;
            if (dictionary.TryGetValue(key, out result))
            {
                return result;
            }

            return defaultValue;
        }
    }
}