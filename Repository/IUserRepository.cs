using KMStore.API.Models;
using System.Threading.Tasks;

namespace KMStore.API.Repository
{
    public interface IUserRepository
    {
        Task Register(User user);

        Task Login(User user);

        Task<User> CheckUserWithSameEmail(string email);
    }
}
