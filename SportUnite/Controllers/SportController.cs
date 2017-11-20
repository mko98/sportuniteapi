using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;
using SportUnite.WEBUI.Models.ViewModels;

namespace SportUnite.WEBUI.Controllers
{
    public class SportController : Controller
    {
        private IManager<SportAttribute> sportAttributeManager;
        private IManager<Sport> sportManager;
        private IManager<SportSportAttribute> sportSportAttributeManager;

        public SportController(IManager<Sport> sportManager, IManager<SportAttribute> sportAttributeManager, IManager<SportSportAttribute> sportSportAttributeManager)
        {
            this.sportManager = sportManager;
            this.sportAttributeManager = sportAttributeManager;
            this.sportSportAttributeManager = sportSportAttributeManager;
        }

        [HttpGet]
        [Authorize]
        public ViewResult ListSports(bool? availability)
        {
            if (!sportManager.Get().Any())
            {
                return View("Home");
            }
            else
            {
                return View(new SportsFilterListViewModel()
                {
                    Sports = sportManager.Get()
                        .Where(p => availability == null || p.Availability == availability)
                        .OrderBy(p => p.SportId),
                    CurrentAvailability = availability.HasValue
                });
            }
        }

        [HttpGet]
        public ViewResult AddSport()
        {
            return View();
        }

        public ViewResult AddSport(Sport sport)
        {
            if (ModelState.IsValid)
            {
                sportManager.Save(sport);
                return View("Thanks", sport);
            }
            else
            {
                // there is a validation error
                return View();
            }
        }

        [Authorize]
        [HttpGet]
        public ViewResult EditSport(int sportId) => View(sportManager.Get().FirstOrDefault(p => p.SportId == sportId));

        [Authorize]
        [HttpPost]
        public IActionResult EditSport(Sport sport)
        {
            if (ModelState.IsValid)
            {
                sportManager.Save(sport);
                return RedirectToAction("ListSports");
            }
            else
            {
                // there is something wrong with the data values
                return View("EditSport");
            }
        }

        [HttpGet]
        public ViewResult DetailSport(int sportId)
        {
            List<SportAttribute> list = new List<SportAttribute>(); //Hier komen de SportAttributen in
            Sport sport = sportManager.Get().SingleOrDefault(x => x.SportId == sportId);

            foreach (var sportSportAttribute in sportSportAttributeManager.Get())
            {
                if (sportSportAttribute.SportId == sportId)
                {
                    list.Add(sportAttributeManager.Get().First(sa => sa.SportAttributeId == sportSportAttribute.SportAttributeId));
                }
            }

            return View(new DetailSportModel { Sport = sport, SportAttributes = list });
        }
    }
}

