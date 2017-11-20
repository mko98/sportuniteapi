using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;
using SportUnite.WEBUI.Models.ViewModels;

namespace SportUnite.WEBUI.Controllers
{
    public class SportComplexController : Controller
    {
        private IManager<SportComplex> sportComplexManager;
        private IManager<SportHall> sportHallManager;

        public SportComplexController(IManager<SportComplex> sportComplexManager, IManager<SportHall> sportHallManager)
        {
            this.sportComplexManager = sportComplexManager;
            this.sportHallManager = sportHallManager;
        }

        [HttpGet]
        [Authorize]
        public ViewResult ListSportComplexes(bool? availability)
        {
            if (!sportComplexManager.Get().Any())
            {
                return View("Home");
            }
            else
            {
                return View(new SportComplexFilterListViewModel()
                {
                    SportComplexes = sportComplexManager.Get()
                        .Where(p => availability == null || p.Availability == availability)
                        .OrderBy(p => p.SportComplexId),
                    CurrentAvailability = availability.HasValue
                });
            }
        }

        [HttpGet]
        public ViewResult AddSportComplex()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddSportComplex(SportComplex sportComplex)
        {
            if (ModelState.IsValid)
            {
                sportComplexManager.Save(sportComplex);
                return View("Thanks", sportComplex);
            }
            else
            {
                // there is a validation error
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ViewResult EditSportComplex(int sportComplexId) => View(sportComplexManager.Get().FirstOrDefault(p => p.SportComplexId == sportComplexId));

        [Authorize]
        [HttpPost]
        public IActionResult EditSportComplex(SportComplex sportComplex)
        {
            if (ModelState.IsValid)
            {
                sportComplexManager.Save(sportComplex);
                return RedirectToAction("ListSportComplexes");
            }
            else
            {
                // there is something wrong with the data values
                return View("ListSportComplexes");
            }
        }

        [HttpGet]
        public ViewResult DetailSportComplex(int sportComplexId)
        {
            SportComplex sportComplex = sportComplexManager.Get().SingleOrDefault(x => x.SportComplexId == sportComplexId);
            var viewModel = new DetailSportComplexModel()
            {
                SportComplex = sportComplex,
                SportHalls = sportHallManager.Get().Where(hall => hall.SportComplex.SportComplexId == sportComplexId)
            };
            return View(viewModel);
        }
    }
}
