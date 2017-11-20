using System.Threading.Tasks;

namespace SportUnite.DAL
{
    public interface IAuthentication
    {
        Task<bool> LoginAsync(string user, string password);

        void SignOutAsync();
    }
}
