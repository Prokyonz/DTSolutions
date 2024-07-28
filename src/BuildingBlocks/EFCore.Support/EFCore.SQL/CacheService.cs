using EFCore.SQL.Interface;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace EFCore.SQL
{
    public class CacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService()
        {
            _cache = MemoryCacheSingleton.Instance.Cache;
        }

        public void SetCacheItem<T>(string key, T value, TimeSpan expirationTime)
        {
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
        public static string ALL_COMPANY = "AllCompany";
        public static string GET_PARENT_COMPANY = "GetParentCompany";
        public static string GET_USER_COMPANY_MAPPING = "GetUserCompanyMapping";
        public static string GET_PARTY_BY_PARTY_TYPE = "GetPartyByPartyType";
        public static string GET_BROKER = "GetBroker";
        public static int CACHE_HOURS = 5;
    }

}
