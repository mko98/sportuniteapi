using Microsoft.AspNetCore.Mvc;

using System.Linq;
using SportUnite.DAL;

namespace SportUnite.WEBUI.Components
{
    public class InvoiceFilterViewComponent : ViewComponent
    {
        private readonly IInvoiceRepository _repository;

        public InvoiceFilterViewComponent(IInvoiceRepository repo)
        {
            _repository = repo;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedAvailability = RouteData?.Values["availability"];
            return View(_repository.Invoices
                .Select(x => x.Availability)
                .Distinct()
                .OrderBy(x => x));
        }
    }
}