using GenePlanet.Cache;
using GenePlanet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenePlanet.Data
{
    public class EmailRepository : IEmailRepository
    {
        private readonly SmartCache _cache;
        private readonly MysqlContext _db;

        public EmailRepository(SmartCache cache, MysqlContext db)
        {
            _cache = cache;
            _db = db;
        }

        public void Initialize()
        {
           _db.BreachedEmails.ToList().ForEach(item =>
           {
               _cache.CreateEntry(item);
           });
        }

        public BreachedEmail CreateEntry(BreachedEmail breachedEmail)
        {
            var result = GetEntry(breachedEmail.Email);

            if (result != null)
            {
                return null;
            }

            _db.BreachedEmails.Add(breachedEmail);
            _db.SaveChanges();
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

            if (result != null)
            {
                _db.BreachedEmails.Remove(result);
                _db.SaveChanges();
            }

            return result != null;
        }
    }
}
