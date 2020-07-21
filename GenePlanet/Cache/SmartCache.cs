using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenePlanet.Data;
using GenePlanet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace GenePlanet.Cache
{
    public class SmartCache
    {
        private readonly IMemoryCache Cache;

        public SmartCache(IMemoryCache cache)
        {
            Cache = cache;
        }

        public BreachedEmail TryGetEntry(string email)
        {
            Cache.TryGetValue(email, out object result);

            return (BreachedEmail) result;
        }

        public bool CreateEntry(BreachedEmail email)
        {
            Cache.Set(email.Email, email);

            return true;
        }

        public BreachedEmail RemoveEntry(string email)
        {
            var result = TryGetEntry(email);

            if (result != null)
            {
                Cache.Remove(email);
            }

            return result;
        }
    }
}
