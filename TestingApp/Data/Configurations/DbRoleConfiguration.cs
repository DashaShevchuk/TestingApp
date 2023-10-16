using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TestingApp.Data.Entities.AppUser;

namespace TestingApp.Data.Configurations
{
    public class DbRoleConfiguration : IEntityTypeConfiguration<DbRole>
    {
        public void Configure(EntityTypeBuilder<DbRole> builder)
        {
            builder.HasMany(e => e.UserRoles)
                .WithOne(e => e.Role);
        }
    }
}
