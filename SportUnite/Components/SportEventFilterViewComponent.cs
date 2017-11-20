using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportUnite.DAL;

namespace SportUnite.WEBUI.Components
{
    public class SportEventFilterViewComponent : ViewComponent
    {
        private readonly ISportEventRepository _repository;

        public SportEventFilterViewComponent(ISportEventRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedAvailability = RouteData?.Values["availability"];
            return View(_repository.SportEvents
                .Select(x => x.Availability)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}