using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TestingApp.Data.EfContext;
using TestingApp.Data.Interfaces.Tests;
using TestingApp.Data.Model;

namespace TestingApp.Data.Features.Tests
{
    public class TestQueries : ITestsQueries
    {
        private readonly EfDbContext context;
        
        public TestQueries(EfDbContext Context)
        {
            context = Context;
        }
        public List<TestCardModel> GetAvailableTests()
        {
            return context.Test.Select(x => new TestCardModel { Id = x.Id, Name = x.Name, Description = x.Description, QuestionsCount= x.TestToQuestions.Count }).ToList();
        }

        public List<GetTestModel> GetTest(int testId)
        {
            var test = context.Test
               .Where(t => t.Id == testId)
               .Select(t => new GetTestModel
               {
                   Id = t.Id,
                   TestName = t.Name,
                   TestDescription = t.Description,
                   Questions = t.TestToQuestions.Select(ttq => new QuestionModel
                   {
                       Id = ttq.QuestionId,
                       QuestionText = ttq.Questions.Text,
                       Answers = ttq.Questions.AnswerToQuestions.Select(atq => new AnswerModel
                       {
                           Id = atq.Answers.Id,
                           Text = atq.Answers.Text,
                           IsRight = atq.Answers.IsRight
                       }).ToList()
                   }).ToList()
               })
               .ToList();

            return test;
        }

        public TestCardModel GetTestById(int id)
        {
            return context.Test
                           .Where(x => x.Id == id)
                           .Select(x => new TestCardModel
                            {
                             Id = x.Id,
                             Name = x.Name,
                             Description = x.Description,
                             QuestionsCount = x.TestToQuestions.Count
                             })
                            .SingleOrDefault();
        }
    }
}
