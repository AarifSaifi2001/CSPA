using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Model;

namespace WebApi.Repository
{
    public interface IUserRepository
    {
        Task<User> Authenticate(string username, string password);

        void Register(string username, string password, string email, long mobileno);

        Task<bool> UserAlreadyExists(string username);

        Task<User> UserInfoAsync(int userId);

        Task UserUpdatePasswordAsync(int userId, UserPasswordUpdateModel userModel);
    }
}