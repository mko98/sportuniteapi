using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace SportUnite.WEBUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        [Authorize]
        public IActionResult AdminHome()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
    }
}