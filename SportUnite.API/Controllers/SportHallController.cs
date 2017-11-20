using System;
using Halcyon.HAL;
using Halcyon.Web.HAL;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;

namespace SportUnite.API.Controllers
{
    [Produces("application/json")]
    [Route("api/sporthalls")]

    public class SportHallController : Controller
    {
        private IManager<SportHall> _sportHallManager;

        public SportHallController(IManager<SportHall> sportHallManager)
        {
            _sportHallManager = sportHallManager;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sporthallFromRepo = _sportHallManager.Get();
            return Ok(sporthallFromRepo);
        }

        [HttpGet("{SportHallId}")]
        public IActionResult Get(int sportHallId)
        {
            var sportHallFromRepo = _sportHallManager.Get(sportHallId);

            if (sportHallFromRepo == null)
            {
                return NotFound();
            }

            return this.HAL(sportHallFromRepo, new Link[]
            {
                new Link("self", "/api/sporthalls/" + sportHallId),
                new Link("put", "/api/sporthalls/" + sportHallId),
                new Link("delete", "/api/sporthalls/" + sportHallId)
            });
        }

        [HttpPost]
        public IActionResult Post([FromBody] SportHall sporthall)
        {
            if (sporthall == null)
            {
                return BadRequest();
            }
            if (!_sportHallManager.Save(sporthall))
            {
                throw new Exception("Creating an sporthall failed on save.");
            }
            return this.HAL(sporthall, new Link[]
            {
                new Link("self", "/api/sporthalls/" + sporthall.SportHallId),
                new Link("get", "/api/sporthalls/"),
                new Link("get", "/api/sporthalls/" + sporthall.SportHallId),
                new Link("put", "/api/sporthalls/" + sporthall.SportHallId),
                new Link("delete", "/api/sporthalls/" + sporthall.SportHallId)
            });
        }

        [HttpDelete("{SportHallId}")]
        public IActionResult Delete(int sporthallId)
        {
            var sporthallFromRepo = _sportHallManager.Get(sporthallId);
            if (sporthallFromRepo == null)
            {
                return NotFound();
            }
            if (!_sportHallManager.Delete(sporthallFromRepo))
            {
                throw new Exception($"Deleting sporthall {sporthallId} failed on save.");
            }
            return NoContent();
        }

        [HttpPut("{SportHallId}")]
        public IActionResult Put(int sporthallId, [FromBody] SportHall sporthall)
        {
            var sporthallFromRepo = _sportHallManager.Get(sporthallId);
            if (sporthallFromRepo == null || sporthall == null)
            {
                return NotFound();
            }
            if (sporthall.Name != null)
            {
                sporthallFromRepo.Name = sporthall.Name;
            }
            if (sporthall.MaxPerson != null)
            {
                sporthallFromRepo.MaxPerson = sporthall.MaxPerson;
            }
            if (sporthall.MinPerson != null)
            {
                sporthallFromRepo.MinPerson = sporthall.MinPerson;
            }
            if (sporthall.Availability != null)
            {
                sporthallFromRepo.Availability = sporthall.Availability;
            }
            if (!_sportHallManager.Save(sporthallFromRepo))
            {
                throw new Exception($"Deleting sporthall {sporthallId} failed on save.");
            }
            return this.HAL(sporthallFromRepo, new Link[]
            {
                new Link("self", "/api/sporthalls/" + sporthallId),
                new Link("get", "/api/sporthalls/"),
                new Link("get", "/api/sporthalls/" + sporthallId),
                new Link("delete", "/api/sporthalls/" + sporthallId)
            });
        }
    }
}