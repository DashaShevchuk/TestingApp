using System.Collections.Generic;

namespace TestingApp.Data.Entities
{
    public class Tests
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<UsersTests> UsersTests { get; set; }

        public virtual ICollection<TestToQuestion> TestToQuestions { get; set; }
    }
}
