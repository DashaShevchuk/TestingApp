using System.Collections.Generic;

namespace TestingApp.Data.Model
{
    public class GetTestModel
    {
        public int Id { get; set; }
        public string TestName { get; set; }
        public string TestDescription { get; set; }
        public List<QuestionModel> Questions { get; set; }

    }
}
