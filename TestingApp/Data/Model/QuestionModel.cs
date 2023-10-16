using System.Collections.Generic;

namespace TestingApp.Data.Model
{
    public class QuestionModel
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public List<AnswerModel> Answers { get; set; }
    }
}
