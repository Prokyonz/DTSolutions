using Microsoft.Extensions.Caching.Memory;
using System;

namespace EFCore.SQL
{
    public class MemoryCacheSingleton
    {
        private static readonly Lazy<MemoryCacheSingleton> lazy = new Lazy<MemoryCacheSingleton>(() => new MemoryCacheSingleton());

        public static MemoryCacheSingleton Instance => lazy.Value;

        public IMemoryCache Cache { get; }

        private MemoryCacheSingleton()
        {
            Cache = new MemoryCache(new MemoryCacheOptions());
        }
    }
}
