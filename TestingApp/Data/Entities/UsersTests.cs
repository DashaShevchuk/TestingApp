using TestingApp.Data.Entities.AppUser;

namespace TestingApp.Data.Entities
{
    public class UsersTests
    {
        public int Id { get; set; }

        public int TestId { get; set; }

        public virtual Tests Test { get; set; }

        public string UserId { get; set; }

        public virtual DbUser User { get; set; }

        public bool IsCompleated { get; set; }

        public int Mark { get; set; }
    }
}
