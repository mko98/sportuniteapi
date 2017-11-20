using System.Linq;using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SportUnite.BLL;
using SportUnite.WEBUI.Models.ViewModels;
using SportUnite.Domain.Models;

namespace SportUnite.WEBUI.Controllers
{
    public class InvoiceController : Controller
    {
        private IManager<Invoice> invoiceManager;

        public InvoiceController(IManager<Invoice> invoiceManager)
        {
            this.invoiceManager = invoiceManager;
        }

        [HttpGet]
        [Authorize]
        public ViewResult ListInvoices(bool? availability)
        {
            if (!invoiceManager.Get().Any())
            {
                return View("Home");
            }
            else
            {
                return View(new InvoiceFilterListViewModel()
                {
                    Invoices = invoiceManager.Get()
                        .Where(p => availability == null || p.Availability == availability)
                        .OrderBy(p => p.InvoiceId),
                    CurrentAvailability = availability.HasValue
                });
            }
        }
    }
}
