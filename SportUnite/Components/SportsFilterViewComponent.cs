using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportUnite.DAL;

namespace SportUnite.WEBUI.Components
{
    public class SportsFilterViewComponent : ViewComponent
    {
        private readonly ISportRepository _repository;

        public SportsFilterViewComponent(ISportRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedAvailability = RouteData?.Values["availability"];
            return View(_repository.Sports
                .Select(x => x.Availability)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}