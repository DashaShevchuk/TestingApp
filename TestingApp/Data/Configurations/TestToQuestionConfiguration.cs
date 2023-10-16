using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApp.Data.Entities;

namespace TestingApp.Data.Configurations
{
    public class TestToQuestionConfiguration : IEntityTypeConfiguration<TestToQuestion>
    {
        public void Configure(EntityTypeBuilder<TestToQuestion> builder)
        {
            builder.HasKey(e => new { e.TestId, e.QuestionId });

            builder.HasOne(e => e.Questions)
                .WithMany(e => e.TestToQuestions)
                .HasForeignKey(e => e.QuestionId)
                .IsRequired();

            builder.HasOne(e => e.Tests)
                .WithMany(e => e.TestToQuestions)
                .HasForeignKey(e => e.TestId)
                .IsRequired();
        }
    }
}
