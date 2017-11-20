using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;
using SportUnite.WEBUI.Models.ViewModels;

namespace SportUnite.WEBUI.Controllers
{
    public class SportEventController : Controller
    {
        private IManager<SportAttribute> sportAttributeManager;
        private IManager<SportComplex> sportComplexManager;
        private IManager<SportEvent> sportEventManager;
        private IManager<SportHall> sportHallManager;
        private IManager<Sport> sportManager;

        public SportEventController(IManager<SportAttribute> sportAttributeManager, IManager<SportComplex> sportComplexManager,
            IManager<SportEvent> sportEventManager, IManager<SportHall> sportHallManager, IManager<Sport> sportManager)
        {
            this.sportAttributeManager = sportAttributeManager;
            this.sportComplexManager = sportComplexManager;
            this.sportEventManager = sportEventManager;
            this.sportHallManager = sportHallManager;
            this.sportAttributeManager = sportAttributeManager;
        }

        [HttpGet]
        [Authorize]
        public ViewResult ListSportEvents(bool? availability)
        {
            if (!sportEventManager.Get().Any())
            {
                return View("Home");
            }
            else
            {
                return View(new SportEventFilterListViewModel()
                {
                    SportEvents = sportEventManager.Get()
                        .Where(p => availability == null || p.Availability == availability)
                        .OrderBy(p => p.SportEventId),
                    CurrentAvailability = availability.HasValue
                });
            }
        }

        [HttpGet]
        public ViewResult AddSportEvent()
        {
            return View(new AddSportEventModel() { SportHalls = sportHallManager.Get(), Sports = sportManager.Get() });
        }

        [HttpPost]
        public ViewResult AddSportEvent(AddSportEventModel model)
        {
            if (ModelState.IsValid)
            {
                model.SportEvent.Sport = sportManager.Get().Single(a => a.SportId == model.SportId);
                model.SportEvent.SportHall = sportHallManager.Get().Single(a => a.SportHallId == model.SportHallId);
                sportEventManager.Save(model.SportEvent);
                return View("Thanks", model.SportEvent);
            }
            else
            {
                // there is a validation error
                return View(new AddSportEventModel() { Sports = sportManager.Get(), SportHalls = sportHallManager.Get() });
            }
        }

        [Authorize]
        [HttpGet]
        public ViewResult EditSportEvent(int sportEventId) => View(sportEventManager.Get().FirstOrDefault(p => p.SportEventId == sportEventId));

        [Authorize]
        [HttpPost]
        public IActionResult EditSportEvent(SportEvent sportEvent)
        {
            if (ModelState.IsValid)
            {
                sportEventManager.Save(sportEvent);
                return RedirectToAction("ListSportEvents");
            }
            else
            {
                // there is something wrong with the data values
                return View("ListSportEvents");
            }
        }

        [HttpGet]
        public ViewResult DetailSportEvent(int sportEventId, int sportId, int sportHallId, int sportComplexId, int sportAttributeId)
        {
            SportEvent sportEvent = sportEventManager.Get().Single(x => x.SportEventId == sportEventId);
            Sport sport = sportManager.Get().SingleOrDefault(x => x.SportId == sportId);
            SportHall sportHall = sportHallManager.Get().SingleOrDefault(x => x.SportHallId == sportHallId);
            SportComplex sportComplex = sportComplexManager.Get().SingleOrDefault(x => x.SportComplexId == sportComplexId);
            SportAttribute sportAttribute = sportAttributeManager.Get().SingleOrDefault(x => x.SportAttributeId == sportAttributeId);
            var viewModel = new DetailSportEventModel(sportEvent, sport, sportHall, sportComplex, sportAttribute);
            return View(viewModel);
        }
    }
}
