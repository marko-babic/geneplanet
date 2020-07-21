using GenePlanet.Cache;
using GenePlanet.Data;
using GenePlanet.Models;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenePlanetTest.Classes
{
    class EmailRepositoryStub : IEmailRepository
    {
        private readonly SmartCache _cache;

        public EmailRepositoryStub()
        {
            _cache = new SmartCache(new MemoryCache(new MemoryCacheOptions { }));
        }

        public void Initialize()
        {
        }

        public BreachedEmail CreateEntry(BreachedEmail breachedEmail)
        {
            var result = GetEntry(breachedEmail.Email);

            if (result != null)
            {
                return null;
            }

            _cache.CreateEntry(breachedEmail);

            return breachedEmail;
        }

        public BreachedEmail GetEntry(string email)
        {
            return _cache.TryGetEntry(email);
        }

        public bool RemoveEntry(string email)
        {
            var result = _cache.RemoveEntry(email);

            return result != null;
        }
    }
}
