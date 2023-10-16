using TestingApp.Data.Entities.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestingApp.Data.Entities;
using TestingApp.Data.Configurations;

namespace TestingApp.Data.EfContext
{
    public class EfDbContext : IdentityDbContext<DbUser, DbRole, string, IdentityUserClaim<string>,
    DbUserRole, IdentityUserLogin<string>,
    IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public EfDbContext(DbContextOptions<EfDbContext> options)
           : base(options)
        {

        }

        public virtual DbSet<Answers> Answer { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Tests> Test { get; set; }
        public virtual DbSet<AnswerToQuestion> AnswerToQuestion { get; set; }
        public virtual DbSet<TestToQuestion> TestToQuestion { get; set; }
        public virtual DbSet<UsersTests> UsersTest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new DbUserConfiguration());
            modelBuilder.ApplyConfiguration(new DbRoleConfiguration());
            modelBuilder.ApplyConfiguration(new DbUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerConfiguration());
            modelBuilder.ApplyConfiguration(new QuestionConfiguration());
            modelBuilder.ApplyConfiguration(new TestConfiguration());
            modelBuilder.ApplyConfiguration(new AnswerToQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new TestToQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new UsersTestsConfiguration());
        }
    }
}
