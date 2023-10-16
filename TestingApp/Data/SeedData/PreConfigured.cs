using TestingApp.Data.Entities.AppUser;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System;
using System.Linq;
using TestingApp.Data.EfContext;
using TestingApp.Data.Entities;

namespace TestingApp.Data.SeedData
{
    public class PreConfigured
    {
        public static async Task SeedRoles(RoleManager<DbRole> roleManager)
        {
            if (!roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new DbRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                });
            }
        }

        public static async Task SeedUsers(UserManager<DbUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                DbUser user1 = new()
                {
                    Name = "Dasha",
                    LastName = "Shevchuk",
                    UserName = "dasha",
                    Email = "77dasha0377@gmail.com",
                    EmailConfirmed = true
                };

                await userManager.CreateAsync(user1, "Qwerty-1");
                await userManager.AddToRoleAsync(user1, "User");
            }
        }

        public static void SeedTests(EfDbContext context)
        {
            Questions question1 = new Questions();
            question1.Text = "What is the plural form of «child» ? ";

            Questions question2 = new Questions();
            question2.Text = "Choose the correct sentence: ";

            Questions question3 = new Questions();
            question3.Text = "Which word is a synonym for «happy»?";

            Questions question4 = new Questions();
            question4.Text = "Select the correctly punctuated sentence:";

            Questions question5 = new Questions();
            question5.Text = "What is the opposite of «begin»?";

            Questions question6 = new Questions();
            question6.Text = "Identify the noun in the following sentence: «The dog barked loudly».";

            Questions question7 = new Questions();
            question7.Text = "Which sentence uses the word «their» correctly?";

            Questions question8 = new Questions();
            question8.Text = "Choose the correct form of «to be» to fill in the blank: «She ___ a doctor»?";

            Questions question9 = new Questions();
            question9.Text = "What is the superlative form of the adjective «tall»?";

            Questions question10 = new Questions();
            question10.Text = "Identify the adverb in the sentence: «She sings beautifully»:";
            
            context.Questions.AddRange(question1, question2, question3, question4, question5, question6, question7, question8, question9, question10);
            context.SaveChanges();


            Answers answer11 = new Answers();
            answer11.Text = "childs";
            answer11.IsRight = false;

            Answers answer12 = new Answers();
            answer12.Text = "childen";
            answer12.IsRight = false;

            Answers answer13 = new Answers();
            answer13.Text = "children";
            answer13.IsRight = true;

            context.Answer.AddRange(answer11, answer12, answer13);
            context.SaveChanges();

            Answers answer21 = new Answers();
            answer21.Text = "He seen the movie last night";
            answer21.IsRight = false;

            Answers answer22 = new Answers();
            answer22.Text = "He seen the movie last night";
            answer22.IsRight = true;

            Answers answer23 = new Answers();
            answer23.Text = "He seen the movie last night";
            answer23.IsRight = false;

            context.Answer.AddRange(answer21, answer22, answer23);
            context.SaveChanges();

            Answers answer31 = new Answers();
            answer31.Text = "Sad";
            answer31.IsRight = false;

            Answers answer32 = new Answers();
            answer32.Text = "Content";
            answer32.IsRight = true;

            Answers answer33 = new Answers();
            answer33.Text = "Angry";
            answer33.IsRight = false;

            context.Answer.AddRange(answer31, answer32, answer33);
            context.SaveChanges();

            Answers answer41 = new Answers();
            answer41.Text = "The cat sat on the table";
            answer41.IsRight = true;

            Answers answer42 = new Answers();
            answer42.Text = "The cat, sat on the table";
            answer42.IsRight = false;

            Answers answer43 = new Answers();
            answer43.Text = "The cat sat, on the table";
            answer43.IsRight = false;

            context.Answer.AddRange(answer41, answer42, answer43);
            context.SaveChanges();

            Answers answer51 = new Answers();
            answer51.Text = "Start";
            answer51.IsRight = false;

            Answers answer52 = new Answers();
            answer52.Text = "Finish";
            answer52.IsRight = true;

            Answers answer53 = new Answers();
            answer53.Text = "Continue";
            answer53.IsRight = false;

            context.Answer.AddRange(answer51, answer52, answer53);
            context.SaveChanges();

            Answers answer61 = new Answers();
            answer61.Text = "The";
            answer61.IsRight = false;

            Answers answer62 = new Answers();
            answer62.Text = "Dog";
            answer62.IsRight = true;

            Answers answer63 = new Answers();
            answer63.Text = "Barked";
            answer63.IsRight = false;

            context.Answer.AddRange(answer61, answer62, answer63);
            context.SaveChanges();

            Answers answer71 = new Answers();
            answer71.Text = "They're going to the store";
            answer71.IsRight = true;

            Answers answer72 = new Answers();
            answer72.Text = "Their going to the store";
            answer72.IsRight = false;

            Answers answer73 = new Answers();
            answer73.Text = "There going to the store";
            answer73.IsRight = false;

            context.Answer.AddRange(answer71, answer72, answer73);
            context.SaveChanges();

            Answers answer81 = new Answers();
            answer81.Text = "am";
            answer81.IsRight = false;

            Answers answer82 = new Answers();
            answer82.Text = "are";
            answer82.IsRight = false;

            Answers answer83 = new Answers();
            answer83.Text = "is";
            answer83.IsRight = true;

            context.Answer.AddRange(answer81, answer82, answer83);
            context.SaveChanges();

            Answers answer91 = new Answers();
            answer91.Text = "Taller";
            answer91.IsRight = false;

            Answers answer92 = new Answers();
            answer92.Text = "Talliest";
            answer92.IsRight = false;

            Answers answer93 = new Answers();
            answer93.Text = "Tallest";
            answer93.IsRight = true;

            context.Answer.AddRange(answer91, answer92, answer93);
            context.SaveChanges();

            Answers answer101 = new Answers();
            answer101.Text = "She";
            answer101.IsRight = false;

            Answers answer102 = new Answers();
            answer102.Text = "Sings";
            answer102.IsRight = false;

            Answers answer103 = new Answers();
            answer103.Text = "Beautifully";
            answer103.IsRight = true;

            context.Answer.AddRange(answer101, answer102, answer103);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion11 = new AnswerToQuestion();
            answerToQuestion11.QuestionId = question1.Id;
            answerToQuestion11.AnswerId = answer11.Id;

            AnswerToQuestion answerToQuestion12 = new AnswerToQuestion();
            answerToQuestion12.QuestionId = question1.Id;
            answerToQuestion12.AnswerId = answer12.Id;

            AnswerToQuestion answerToQuestion13 = new AnswerToQuestion();
            answerToQuestion13.QuestionId = question1.Id;
            answerToQuestion13.AnswerId = answer13.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion11, answerToQuestion12, answerToQuestion13);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion21 = new AnswerToQuestion();
            answerToQuestion21.QuestionId = question2.Id;
            answerToQuestion21.AnswerId = answer21.Id;

            AnswerToQuestion answerToQuestion22 = new AnswerToQuestion();
            answerToQuestion22.QuestionId = question2.Id;
            answerToQuestion22.AnswerId = answer22.Id;

            AnswerToQuestion answerToQuestion23 = new AnswerToQuestion();
            answerToQuestion23.QuestionId = question2.Id;
            answerToQuestion23.AnswerId = answer23.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion21, answerToQuestion22, answerToQuestion23);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion31 = new AnswerToQuestion();
            answerToQuestion31.QuestionId = question3.Id;
            answerToQuestion31.AnswerId = answer31.Id;

            AnswerToQuestion answerToQuestion32 = new AnswerToQuestion();
            answerToQuestion32.QuestionId = question3.Id;
            answerToQuestion32.AnswerId = answer32.Id;

            AnswerToQuestion answerToQuestion33 = new AnswerToQuestion();
            answerToQuestion33.QuestionId = question3.Id;
            answerToQuestion33.AnswerId = answer33.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion31, answerToQuestion32, answerToQuestion33);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion41 = new AnswerToQuestion();
            answerToQuestion41.QuestionId = question4.Id;
            answerToQuestion41.AnswerId = answer41.Id;

            AnswerToQuestion answerToQuestion42 = new AnswerToQuestion();
            answerToQuestion42.QuestionId = question4.Id;
            answerToQuestion42.AnswerId = answer42.Id;

            AnswerToQuestion answerToQuestion43 = new AnswerToQuestion();
            answerToQuestion43.QuestionId = question4.Id;
            answerToQuestion43.AnswerId = answer43.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion41, answerToQuestion42, answerToQuestion43);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion51 = new AnswerToQuestion();
            answerToQuestion51.QuestionId = question5.Id;
            answerToQuestion51.AnswerId = answer51.Id;

            AnswerToQuestion answerToQuestion52 = new AnswerToQuestion();
            answerToQuestion52.QuestionId = question5.Id;
            answerToQuestion52.AnswerId = answer52.Id;

            AnswerToQuestion answerToQuestion53 = new AnswerToQuestion();
            answerToQuestion53.QuestionId = question5.Id;
            answerToQuestion53.AnswerId = answer53.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion51, answerToQuestion52, answerToQuestion53);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion61 = new AnswerToQuestion();
            answerToQuestion61.QuestionId = question6.Id;
            answerToQuestion61.AnswerId = answer61.Id;

            AnswerToQuestion answerToQuestion62 = new AnswerToQuestion();
            answerToQuestion62.QuestionId = question6.Id;
            answerToQuestion62.AnswerId = answer62.Id;

            AnswerToQuestion answerToQuestion63 = new AnswerToQuestion();
            answerToQuestion63.QuestionId = question6.Id;
            answerToQuestion63.AnswerId = answer63.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion61, answerToQuestion62, answerToQuestion63);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion71 = new AnswerToQuestion();
            answerToQuestion71.QuestionId = question7.Id;
            answerToQuestion71.AnswerId = answer71.Id;

            AnswerToQuestion answerToQuestion72 = new AnswerToQuestion();
            answerToQuestion72.QuestionId = question7.Id;
            answerToQuestion72.AnswerId = answer72.Id;

            AnswerToQuestion answerToQuestion73 = new AnswerToQuestion();
            answerToQuestion73.QuestionId = question7.Id;
            answerToQuestion73.AnswerId = answer73.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion71, answerToQuestion72, answerToQuestion73);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion81 = new AnswerToQuestion();
            answerToQuestion81.QuestionId = question8.Id;
            answerToQuestion81.AnswerId = answer81.Id;

            AnswerToQuestion answerToQuestion82 = new AnswerToQuestion();
            answerToQuestion82.QuestionId = question8.Id;
            answerToQuestion82.AnswerId = answer82.Id;

            AnswerToQuestion answerToQuestion83 = new AnswerToQuestion();
            answerToQuestion83.QuestionId = question8.Id;
            answerToQuestion83.AnswerId = answer83.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion81, answerToQuestion82, answerToQuestion83);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion91 = new AnswerToQuestion();
            answerToQuestion91.QuestionId = question9.Id;
            answerToQuestion91.AnswerId = answer91.Id;

            AnswerToQuestion answerToQuestion92 = new AnswerToQuestion();
            answerToQuestion92.QuestionId = question9.Id;
            answerToQuestion92.AnswerId = answer92.Id;

            AnswerToQuestion answerToQuestion93 = new AnswerToQuestion();
            answerToQuestion93.QuestionId = question9.Id;
            answerToQuestion93.AnswerId = answer93.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion91, answerToQuestion92, answerToQuestion93);
            context.SaveChanges();

            AnswerToQuestion answerToQuestion101 = new AnswerToQuestion();
            answerToQuestion101.QuestionId = question10.Id;
            answerToQuestion101.AnswerId = answer101.Id;

            AnswerToQuestion answerToQuestion102 = new AnswerToQuestion();
            answerToQuestion102.QuestionId = question10.Id;
            answerToQuestion102.AnswerId = answer102.Id;

            AnswerToQuestion answerToQuestion103 = new AnswerToQuestion();
            answerToQuestion103.QuestionId = question10.Id;
            answerToQuestion103.AnswerId = answer103.Id;

            context.AnswerToQuestion.AddRange(answerToQuestion101, answerToQuestion102, answerToQuestion103);
            context.SaveChanges();

            Tests test1 = new Tests();
            test1.Name = "Grammar and Vocabulary Proficiency Test";
            test1.Description = "This test is designed to assess your knowledge of English grammar and vocabulary. It covers a range of topics, including plurals, verb tenses, synonyms, punctuation, opposites, parts of speech, and more. ";
            context.Test.Add(test1);
            context.SaveChanges();

            TestToQuestion testToQuestion1 = new TestToQuestion();
            testToQuestion1.QuestionId = question1.Id;
            testToQuestion1.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion1);
            context.SaveChanges();//після першого не додається

            TestToQuestion testToQuestion2 = new TestToQuestion();
            testToQuestion2.QuestionId = question2.Id;
            testToQuestion2.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion2);
            context.SaveChanges();

            TestToQuestion testToQuestion3 = new TestToQuestion();
            testToQuestion3.QuestionId = question3.Id;
            testToQuestion3.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion3);
            context.SaveChanges();

            TestToQuestion testToQuestion4 = new TestToQuestion();
            testToQuestion4.QuestionId = question4.Id;
            testToQuestion4.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion4);
            context.SaveChanges();

            TestToQuestion testToQuestion5 = new TestToQuestion();
            testToQuestion5.QuestionId = question5.Id;
            testToQuestion5.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion5);
            context.SaveChanges();

            TestToQuestion testToQuestion6 = new TestToQuestion();
            testToQuestion6.QuestionId = question6.Id;
            testToQuestion6.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion6);
            context.SaveChanges();

            TestToQuestion testToQuestion7 = new TestToQuestion();
            testToQuestion7.QuestionId = question7.Id;
            testToQuestion7.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion7);
            context.SaveChanges();

            TestToQuestion testToQuestion8 = new TestToQuestion();
            testToQuestion8.QuestionId = question8.Id;
            testToQuestion8.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion8);
            context.SaveChanges();

            TestToQuestion testToQuestion9 = new TestToQuestion();
            testToQuestion9.QuestionId = question9.Id;
            testToQuestion9.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion9);
            context.SaveChanges();

            TestToQuestion testToQuestion10 = new TestToQuestion();
            testToQuestion10.QuestionId = question10.Id;
            testToQuestion10.TestId = test1.Id;

            context.TestToQuestion.Add(testToQuestion10);
            context.SaveChanges();
        }
    }
}
