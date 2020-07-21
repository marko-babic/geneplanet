using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GenePlanet.Models;
using Microsoft.AspNetCore.Http;
using System.Reflection.Metadata.Ecma335;
using GenePlanet.Cache;
using GenePlanet.Data;

namespace GenePlanet.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BreachedEmailsController : ControllerBase
    {
        private readonly IEmailRepository _repo;

        public BreachedEmailsController(IEmailRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("{email}", Name = "GetEmail")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetEmail(string email)
        {
            var response = _repo.GetEntry(email);

            if (response == null)
            {
                return NotFound();
            }

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult AddEmail([FromBody] BreachedEmail email)
        {
            var response = _repo.CreateEntry(email);

            if (response == null)
            {
                return Conflict();
            }

            return CreatedAtRoute(
                "GetEmail",
                new { email = email.Email },
                email
            );
        }

        [HttpDelete("{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult DeleteEmail(string email)
        {
            _repo.RemoveEntry(email);

            return Ok();
        }
    }
}
