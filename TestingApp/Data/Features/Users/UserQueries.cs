using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using TestingApp.Data.Entities.AppUser;
using TestingApp.Data.Interfaces.User;

namespace TestingApp.Data.Features.Users
{
    public class UserQueries : IUserQueries
    {
        private readonly UserManager<DbUser> userManager;
        public UserQueries(UserManager<DbUser> UserManager)
        {
            userManager = UserManager;
        }
        public async Task<DbUser> GetUserByEmail(string email)
        {
            return await userManager.FindByEmailAsync(email);
        }
    }
}
