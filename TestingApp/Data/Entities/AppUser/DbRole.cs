using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace TestingApp.Data.Entities.AppUser
{
    public class DbRole: IdentityRole<string>
    {
        public virtual ICollection<DbUserRole> UserRoles { get; set; }
    }
}
