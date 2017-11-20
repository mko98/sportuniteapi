using System;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;

namespace SportUnite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/sports")]
    public class SportsController : Controller
    {
        private IManager<Sport> _sportManager;

        public SportsController(IManager<Sport> sportManager)
        {
            _sportManager = sportManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sportsFromRepo = _sportManager.Get();

            return Ok(sportsFromRepo);
        }

        [HttpGet("{SportId}")]
        public IActionResult Get(int sportId)
        {
            var sportFromRepo = _sportManager.Get(sportId);

            if (sportFromRepo == null)
            {
                return NotFound();
            }

            return this.HAL(sportFromRepo, new Link[]
            {
                new Link("self", "/api/sports/" + sportId),
                new Link("put", "/api/sports/" + sportId),
                new Link("delete", "/api/sports/" + sportId)
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] Sport sport)
        {
            if (sport == null)
            {
                return BadRequest();
            }
            if (!_sportManager.Save(sport))
            {
                throw new Exception("Creating an author failed on save.");
            }
            return this.HAL(sport, new Link[]
            {
                new Link("self", "/api/sports/" + sport.SportId),
                new Link("get", "/api/sports/"),
                new Link("get", "/api/sports/" + sport.SportId),
                new Link("put", "/api/sports/" + sport.SportId),
                new Link("delete", "/api/sports/" + sport.SportId)
            });
        }

        [HttpDelete("{SportId}")]
        public IActionResult Delete(int sportId)
        {
            var sportFromRepo = _sportManager.Get(sportId);
            if (sportFromRepo == null)
            {
                return NotFound();
            }
            if (!_sportManager.Delete(sportFromRepo))
            {
                throw new Exception($"Deleting author {sportId} failed on save.");
            }
            return NoContent();
        }

        [HttpPut("{SportId}")]
        public IActionResult Put(int sportId, [FromBody] Sport sport)
        {
            var sportFromRepo = _sportManager.Get(sportId);
            if (sportFromRepo == null || sport == null)
            {
                return NotFound();
            }
            if (sport.Name != null)
            {
                sportFromRepo.Name = sport.Name;
            }
            if (sport.Description != null)
            {
                sportFromRepo.Description = sport.Description;
            }
            if (sport.Availability != null)
            {
                sportFromRepo.Availability = sport.Availability;
            }
            if (!_sportManager.Save(sportFromRepo))
            {
                throw new Exception($"Deleting author {sportId} failed on save.");
            }
            return this.HAL(sportFromRepo, new Link[]
            {
                new Link("self", "/api/sports/" + sportId),
                new Link("get", "/api/sports/"),
                new Link("get", "/api/sports/" + sportId),
                new Link("delete", "/api/sports/" + sportId)
            });
        }
    }
}
