using GenePlanet.Cache;
using GenePlanet.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GenePlanetTest.Classes
{
    public class SmartCacheData
    {
        public static IEnumerable<object[]> InsertData =>
            new List<object[]>
            {
                new object[] { GetSample(), true },
            };

        public static IEnumerable<object[]> ReadData =>
            new List<object[]>
            {
                new object[] { GetEmail(), GetSample() },
                new object[] { GetFailEmail(), null },
            };

        public static IEnumerable<object[]> RemoveData =>
            new List<object[]>
            {
                new object[] { GetEmail(), GetSample() },
                new object[] { GetFailEmail(), null },
            };

        public static IEnumerable<object[]> GetRepoData =>
            new List<object[]>
            {
                new object[] { GetEmail(), null },
            };

        public static IEnumerable<object[]> CreateAndGetRepoData =>
            new List<object[]>
            {
                new object[] { GetEmail(), GetSample() },
            };

        public static BreachedEmail GetSample()
        {
            return new BreachedEmail { 
                Email = GetEmail(), 
                Id = 122 
            };
        }

        private static string GetEmail()
        {
            return "marko.skace@gmail.com";
        }

        private static string GetFailEmail()
        {
            return "marko.skace@gmail.co";
        }
    }
}
