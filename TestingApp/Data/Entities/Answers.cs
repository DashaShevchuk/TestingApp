using System.Collections.Generic;

namespace TestingApp.Data.Entities
{
    public class Answers
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public bool IsRight { get; set; }

        public virtual ICollection<AnswerToQuestion> AnswerToQuestions { get; set; }
    }
}
