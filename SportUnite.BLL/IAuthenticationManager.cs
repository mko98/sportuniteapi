using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SportUnite.BLL
{
    public interface IAuthenticationManager
    {
        Task<bool> LoginAsync(string user, string password);

        void SignOutAsync();
    }
}
