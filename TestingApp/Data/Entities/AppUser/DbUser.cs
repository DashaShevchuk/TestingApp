using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TestingApp.Data.Entities.AppUser
{
    public class DbUser :IdentityUser
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public virtual ICollection<DbUserRole> UserRoles { get; set; }

        public virtual ICollection<UsersTests> UsersTests { get; set; }
    }
}
