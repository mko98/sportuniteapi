using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SportUnite.DAL;

namespace SportUnite.BLL
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private IAuthentication authentication;

        public AuthenticationManager(IAuthentication authentication)
        {
            this.authentication = authentication;
        }

        public Task<bool> LoginAsync(string user, string password)
        {
            return authentication.LoginAsync(user, password);
        }

        public void SignOutAsync()
        {
            authentication.SignOutAsync();
        }
    }
}
