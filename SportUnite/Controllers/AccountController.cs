using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SportUnite.WEBUI.Models.ViewModels;
using SportUnite.DAL;

namespace SportUnite.WEBUI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private IAuthentication authentication;

        //In plaats van de UserManager en SignInManager gebruik een zelfgemaakte IAuthentication interface die de UserManager en SignInManager voor ons instantieert
        public AccountController(IAuthentication authObject)
        {
            this.authentication = authObject;
        }

        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            System.Diagnostics.Debug.WriteLine("Abc");
            if (ModelState.IsValid)
            {
                    if (await authentication.LoginAsync(loginModel.Username, loginModel.Password))
                    {
                    System.Diagnostics.Debug.WriteLine("adasdasd");
                    return Redirect(loginModel?.ReturnUrl ?? "/Home/Home");
                    }
            }
            ModelState.AddModelError("", "Ongeldige gebruikersnaam of wachtwoord");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/Home/Home")
        {
            authentication.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}