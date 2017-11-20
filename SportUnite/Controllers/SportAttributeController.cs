using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportUnite.BLL;
using SportUnite.Domain.Models;
using SportUnite.WEBUI.Models.ViewModels;

namespace SportUnite.WEBUI.Controllers
{
    public class SportAttributeController : Controller
    {
        private IManager<SportAttribute> sportAttributeManager;
        private IManager<Sport> sportManager;

        public SportAttributeController(IManager<SportAttribute> sportAttributeManager, IManager<Sport> sportManager)
        {
            this.sportAttributeManager = sportAttributeManager;
            this.sportManager = sportManager;
        }

        [HttpGet]
        [Authorize]
        public ViewResult ListSportAttributes(bool? availability)
        {
            if (!sportAttributeManager.Get().Any())
            {
                return View("Home");
            }
            else
            {
                return View(new SportAttributesFilterListViewModel()
                {
                    SportAttributes = sportAttributeManager.Get()
                        .Where(p => availability == null || p.Availability == availability)
                        .OrderBy(p => p.SportAttributeId),
                    CurrentAvailability = availability.HasValue
                });
            }
        }

        [HttpGet]
        public ViewResult AddSportAttribute()
        {
            return View(new AddSportAttributeModel() { Sports = sportManager.Get() });
        }

        [HttpPost]
        public ViewResult AddSportAttribute(AddSportAttributeModel model)
        {
            if (ModelState.IsValid)
            {
                Sport sport = sportManager.Get().Single(a => a.SportId == model.SportId);
                SportSportAttribute sportSportAttribute = new SportSportAttribute() { Sport = sport, SportAttribute = model.SportAttribute };

                model.SportAttribute.SportSportAttributes.Add(sportSportAttribute);
                sport.SportSportAttributes.Add(sportSportAttribute);

                sportManager.Save(sport);
                sportAttributeManager.Save(model.SportAttribute);
                return View("Thanks", model.SportAttribute);
            }
            else
            {
                // there is a validation error
                return View(new AddSportAttributeModel() { Sports = sportManager.Get() });
            }
        }

        [Authorize]
        [HttpGet]
        public ViewResult EditSportAttribute(int sportAttributeId) => View(sportAttributeManager.Get().FirstOrDefault(p => p.SportAttributeId == sportAttributeId));

        [Authorize]
        [HttpPost]
        public IActionResult EditSportAttribute(SportAttribute sportAttribute)
        {
            if (ModelState.IsValid)
            {
                sportAttributeManager.Save(sportAttribute);
                return RedirectToAction("ListSportAttributes");
            }
            else
            {
                // there is something wrong with the data values
                return View("ListSportAttributes");
            }
        }
    }
}
