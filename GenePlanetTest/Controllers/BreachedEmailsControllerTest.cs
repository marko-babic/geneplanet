using GenePlanet.Cache;
using GenePlanet.Controllers;
using GenePlanet.Data;
using GenePlanet.Models;
using GenePlanetTest.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GenePlanetTest.Controllers
{

    public class BreachedEmailsControllerTest
    {
        private readonly BreachedEmailsController _controller;
        private readonly EmailRepositoryStub _repoStub;

        public BreachedEmailsControllerTest()
        {
            _repoStub = new EmailRepositoryStub();
            _controller = new BreachedEmailsController(_repoStub);
        }
        
        [Fact(DisplayName = "Get email not found in cache repository response")]
        public void Get_NotFound_Response()
        {
            var result = _controller.GetEmail(GetEmail());
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact(DisplayName = "Get email found in cache repository response")]
        public void Get_OK_Response()
        {
            _repoStub.CreateEntry(GetDummy());
            var response = _controller.GetEmail(GetEmail());
            Assert.IsAssignableFrom<OkObjectResult>(response);
        }

        [Fact(DisplayName = "Post email success response")]
        public void Post_Add_Email_Success()
        {
            var response = _controller.AddEmail(GetDummy());
            Assert.IsAssignableFrom<CreatedAtRouteResult>(response);
        }

        [Fact(DisplayName = "Post email conflict response")]
        public void Post_Add_Email_Conflict()
        {
            _repoStub.CreateEntry(GetDummy());
            var response = _controller.AddEmail(GetDummy());
            Assert.IsAssignableFrom<ConflictResult>(response);
        }

        [Fact(DisplayName = "Delete email success response")]
        public void Delete_email_OK_response()
        {
            var response = _controller.DeleteEmail(GetEmail());
            Assert.IsAssignableFrom<OkResult>(response);
        }

        private BreachedEmail GetDummy()
        {
            return new BreachedEmail
            {
                Email = GetEmail()
            };
        }

        private string GetEmail()
        {
            return "marko.skace@gmail.com";
        }
    }
}
