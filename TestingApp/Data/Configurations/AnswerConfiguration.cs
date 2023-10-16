using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApp.Data.Entities;

namespace TestingApp.Data.Configurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answers>
    {
        public void Configure(EntityTypeBuilder<Answers> builder)
        {
            builder.HasMany(e => e.AnswerToQuestions)
                 .WithOne(e => e.Answers);
        }
    }
}
