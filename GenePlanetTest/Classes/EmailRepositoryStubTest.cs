using GenePlanet.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GenePlanetTest.Classes
{
    public class EmailRepositoryStubTest
    {
        private readonly EmailRepositoryStub _repo;

        public EmailRepositoryStubTest()
        {
            _repo = new EmailRepositoryStub();
        }

        [Theory(DisplayName = "Get entry from cache repo")]
        [MemberData(nameof(SmartCacheData.GetRepoData), MemberType = typeof(SmartCacheData))]
        public void TestGetEntry(string email, BreachedEmail expected)
        {
            Assert.Equal(_repo.GetEntry(email), expected);
        }

        [Theory(DisplayName = "Create and get entry from cache repo")]
        [MemberData(nameof(SmartCacheData.CreateAndGetRepoData), MemberType = typeof(SmartCacheData))]
        public void TestCreateAndGetEntry(string email, BreachedEmail expected)
        {
            _repo.CreateEntry(expected);
            Assert.Equal(_repo.GetEntry(email).Id, expected.Id);
        }

        [Theory(DisplayName = "Remove non-existent entry from cache repo")]
        [InlineData("marko.skace@gmail.com", false)]
        public void TestRemoveNonEntry(string email, bool expected)
        {
            Assert.Equal(_repo.RemoveEntry(email), expected);
        }

        [Theory(DisplayName = "Remove existent entry from cache repo")]
        [InlineData("marko.skace@gmail.com", true)]
        public void TestRemoveEntry(string email, bool expected)
        {
            _repo.CreateEntry(new BreachedEmail { Email = email });
            Assert.Equal(_repo.RemoveEntry(email), expected);
        }
    }
}
