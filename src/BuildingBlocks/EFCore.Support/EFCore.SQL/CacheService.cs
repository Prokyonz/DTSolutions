using Microsoft.Extensions.Caching.Memory;
using System;

namespace EFCore.SQL
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;
        private readonly bool _isCacheEnabled;

        public CacheService(bool isCacheEnabled= false)
        {
            _isCacheEnabled = isCacheEnabled; ;
            _cache = MemoryCacheSingleton.Instance.Cache;
        }

        public void SetCacheItem<T>(string key, T value, TimeSpan expirationTime)
        {
            if (_isCacheEnabled)
                _cache.Set(key, value, new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = expirationTime
                });
        }

        public T GetCacheItem<T>(string key)
        {
            _cache.TryGetValue(key, out T value);
            return value;
        }

        public bool RemoveCacheItem(string key)
        {
            _cache.Remove(key);
            return true;
        }
    }

    public static class CacheConstant
    {
        public static string ALL_COMPANY { get; set; } = "AllCompany";
        public static string ALL_SIZE { get; set; } = "AllSize";
        public static string GET_PARENT_COMPANY { get; set; } = "GetParentCompany";
        public static string GET_USER_COMPANY_MAPPING { get; set; } = "GetUserCompanyMapping";
        public static string GET_PARTY_BY_PARTY_TYPE { get; set; } = "GetPartyByPartyType";
        public static string GET_BROKER { get; set; } = "GetBroker";
        public static int CACHE_HOURS { get; set; } = 5;
    }

}
