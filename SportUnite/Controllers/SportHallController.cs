using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;
using SportUnite.WEBUI.Models.ViewModels;

namespace SportUnite.WEBUI.Controllers
{
    public class SportHallController : Controller
    {
        private IManager<SportComplex> sportComplexManager;
        private IManager<SportHall> sportHallManager;

        public SportHallController(IManager<SportHall> sportHallManager, IManager<SportComplex> sportComplexManager)
        {
            this.sportHallManager = sportHallManager;
            this.sportComplexManager = sportComplexManager;
        }

        [HttpGet]
        [Authorize]
        public ViewResult ListSportHalls(bool? availability)
        {
            if (!sportHallManager.Get().Any())
            {
                return View("Home");
            }
            else
            {
                return View(new SportHallFilterListViewModel()
                {
                    SportHall = sportHallManager.Get()
                        .Where(p => availability == null || p.Availability == availability)
                        .OrderBy(p => p.SportHallId),
                    CurrentAvailability = availability.HasValue
                });
            }
        }

        [HttpGet]
        public ViewResult AddSportHall()
        {
            return View(new AddSportHallModel() { SportComplexes = sportComplexManager.Get() });
        }

        [HttpPost]
        public ViewResult AddSportHall(AddSportHallModel model)
        {
            if (ModelState.IsValid)
            {
                model.SportHall.SportComplex = sportComplexManager.Get().Single(a => a.SportComplexId == model.SportComplexId);
                sportHallManager.Save(model.SportHall);
                return View("Thanks", model.SportHall);
            }
            else
            {
                return View(new AddSportHallModel() { SportComplexes = sportComplexManager.Get() });
            }
        }

        [Authorize]
        [HttpGet]
        public ViewResult EditSportHall(int sportHallId)
        {
            return View(sportHallManager.Get().FirstOrDefault(p => p.SportHallId == sportHallId));
        }

        [Authorize]
        [HttpPost]
        public IActionResult EditSportHall(SportHall sportHall)
        {
            if (ModelState.IsValid)
            {
                sportHallManager.Save(sportHall);
                return RedirectToAction("ListSportHalls");
            }
            else
            {
                // there is something wrong with the data values
                return View("EditSportHall");
            }
        }
    }
}
