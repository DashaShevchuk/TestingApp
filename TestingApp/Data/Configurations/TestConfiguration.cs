using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApp.Data.Entities;

namespace TestingApp.Data.Configurations
{
    public class TestConfiguration : IEntityTypeConfiguration<Tests>
    {
        public void Configure(EntityTypeBuilder<Tests> builder)
        {
            builder.HasMany(e => e.TestToQuestions)
                 .WithOne(e => e.Tests);

            builder.HasMany(e => e.UsersTests)
               .WithOne(e => e.Test);
        }
    }
}
