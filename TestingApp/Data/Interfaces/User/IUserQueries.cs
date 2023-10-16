using System.Threading.Tasks;
using TestingApp.Data.Entities.AppUser;

namespace TestingApp.Data.Interfaces.User
{
    public interface IUserQueries
    {
        Task<DbUser> GetUserByEmail(string email);
    }
}
