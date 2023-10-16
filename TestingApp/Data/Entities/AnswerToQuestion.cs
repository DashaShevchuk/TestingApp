namespace TestingApp.Data.Entities
{
    public class AnswerToQuestion
    {
        public int QuestionId { get; set; }
        public virtual Questions Questions { get; set; }

        public int AnswerId { get; set; }
        public virtual Answers Answers { get; set; }
    }
}
