using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Threading.Tasks;

namespace SportUnite.DAL
{
    public class UserAuthentication : IAuthentication
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        //Door de UserManager en SignInManager in de authentication constructor te zetten worden deze automatisch geinstantieerd bij het DI of Mocken
        public UserAuthentication(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
        }

        public async Task<bool> LoginAsync(string user, string password)
        {
            IdentityUser identityUser = await userManager.FindByNameAsync(user);

            if (identityUser != null)
            {
                await signInManager.SignOutAsync();

                if ((await signInManager.PasswordSignInAsync(user, password, false, false)).Succeeded)
                {
                    return true;
                }
            }
            return false;
        }

        public async void SignOutAsync()
        {
            await signInManager.SignOutAsync();
        }

    }
}
