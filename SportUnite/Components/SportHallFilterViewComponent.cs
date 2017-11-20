using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportUnite.DAL;

namespace SportUnite.WEBUI.Components
{
    public class SportHallFilterViewComponent : ViewComponent
    {
        private readonly ISportHallRepository _repository;

        public SportHallFilterViewComponent(ISportHallRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedAvailability = RouteData?.Values["availability"];
            return View(_repository.SportHalls
                .Select(x => x.Availability)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}