using GenePlanet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenePlanet.Data
{
    public interface IEmailRepository
    {
        public BreachedEmail CreateEntry(BreachedEmail breachedEmail);
        public BreachedEmail GetEntry(string email);
        public bool RemoveEntry(string email);
        public void Initialize();
    }
}
