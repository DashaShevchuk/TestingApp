using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApp.Data.Entities;

namespace TestingApp.Data.Configurations
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Questions>
    {
        public void Configure(EntityTypeBuilder<Questions> builder)
        {
            builder.HasMany(e => e.AnswerToQuestions)
                 .WithOne(e => e.Questions);

            builder.HasMany(e => e.TestToQuestions)
                .WithOne(e => e.Questions);
        }
    }
}
