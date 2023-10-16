using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestingApp.Data.Entities;
using TestingApp.Data.Entities.AppUser;

namespace TestingApp.Data.Configurations
{
    public class AnswerToQuestionConfiguration : IEntityTypeConfiguration<AnswerToQuestion>
    {
        public void Configure(EntityTypeBuilder<AnswerToQuestion> builder)
        {
            builder.HasKey(e => new { e.AnswerId, e.QuestionId });

            builder.HasOne(e => e.Questions)
                .WithMany(e => e.AnswerToQuestions)
                .HasForeignKey(e => e.QuestionId)
                .IsRequired();

            builder.HasOne(e => e.Answers)
                .WithMany(e => e.AnswerToQuestions)
                .HasForeignKey(e => e.AnswerId)
                .IsRequired();
        }
    }
}
