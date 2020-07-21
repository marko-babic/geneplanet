using GenePlanet.Cache;
using GenePlanet.Models;
using GenePlanetTest.Classes;
using Microsoft.Extensions.Caching.Memory;
using System;
using Xunit;

namespace GenePlanetTest.Classes
{
    public class SmartCacheTest
    {
        private readonly SmartCache _smartCache;
        private readonly IMemoryCache _cache;
        public SmartCacheTest()
        {
            _cache = new MemoryCache(new MemoryCacheOptions { });
            _smartCache = new SmartCache(_cache);
            _cache.Set("marko.skace@gmail.com", SmartCacheData.GetSample());
        }

        [Theory(DisplayName = "Add new email to the cache")]
        [MemberData(nameof(SmartCacheData.InsertData), MemberType= typeof(SmartCacheData))]
        public void TestCreateEntry(BreachedEmail email, bool expected)
        {
            Assert.Equal(_smartCache.CreateEntry(email), expected);
        }

        [Theory(DisplayName = "Get the email from cache")]
        [MemberData(nameof(SmartCacheData.ReadData), MemberType = typeof(SmartCacheData))]
        public void TestTryGetEntry(string email, BreachedEmail expected)
        {
            if (expected == null)
            {
                Assert.Equal(_smartCache.TryGetEntry(email), expected);
            } 
            else
            {
                Assert.Equal(_smartCache.TryGetEntry(email).Id, expected.Id);
            }
        }

        [Theory(DisplayName = "Remove email from cache")]
        [MemberData(nameof(SmartCacheData.RemoveData), MemberType = typeof(SmartCacheData))]
        public void TestRemoveEntry(string email, BreachedEmail expected)
        {
            if (expected == null)
            {
                Assert.Equal(_smartCache.RemoveEntry(email), expected);
            }
            else
            {
                Assert.Equal(_smartCache.RemoveEntry(email).Id, expected.Id);
            }
        }
    }
}