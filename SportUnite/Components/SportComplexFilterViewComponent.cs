using Microsoft.AspNetCore.Mvc;
using System.Linq;
using SportUnite.DAL;

namespace SportUnite.WEBUI.Components
{
    public class SportComplexFilterViewComponent : ViewComponent
    {
        private readonly ISportComplexRepository _repository;

        public SportComplexFilterViewComponent(ISportComplexRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedAvailability = RouteData?.Values["availability"];
            return View(_repository.SportComplex
                .Select(x => x.Availability)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}