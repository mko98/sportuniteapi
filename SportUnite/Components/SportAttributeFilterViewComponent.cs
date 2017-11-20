using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportUnite.DAL;

namespace SportUnite.WEBUI.Components
{
    public class SportAttributeFilterViewComponent : ViewComponent
    {
        private readonly ISportAttributeRepository _repository;

        public SportAttributeFilterViewComponent(ISportAttributeRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedAvailability = RouteData?.Values["availability"];
            return View(_repository.SportAttributes
                .Select(x => x.Availability)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}