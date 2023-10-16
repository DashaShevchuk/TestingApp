namespace TestingApp.Data.Entities
{
    public class TestToQuestion
    {
        public int QuestionId { get; set; }
        public virtual Questions Questions { get; set; }

        public int TestId { get; set; }
        public virtual Tests Tests { get; set; }
    }
}
