using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApp.Data.Entities;
using TestingApp.Data.Entities.AppUser;

namespace TestingApp.Data.Configurations
{
    public class UsersTestsConfiguration : IEntityTypeConfiguration<UsersTests>
    {
        public void Configure(EntityTypeBuilder<UsersTests> builder)
        {
            builder.HasKey(e => new { e.UserId, e.TestId });

            builder.HasOne(e => e.User)
                .WithMany(e => e.UsersTests)
                .HasForeignKey(e => e.UserId)
                .IsRequired();

            builder.HasOne(e => e.Test)
                .WithMany(e => e.UsersTests)
                .HasForeignKey(e => e.TestId)
                .IsRequired();
        }
    }
}
