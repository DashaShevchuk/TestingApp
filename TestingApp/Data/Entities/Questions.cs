using System.Collections.Generic;

namespace TestingApp.Data.Entities
{
    public class Questions
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<AnswerToQuestion> AnswerToQuestions { get; set; }

        public virtual ICollection<TestToQuestion> TestToQuestions { get; set; }

    }
}
