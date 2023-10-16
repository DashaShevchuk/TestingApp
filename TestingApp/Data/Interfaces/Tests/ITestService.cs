using System.Collections.Generic;
using TestingApp.Data.Model;

namespace TestingApp.Data.Interfaces.Tests
{
    public interface ITestService
    {
        public List<TestCardModel> GetAvailableTests();

        public TestCardModel GetAvailableTestPreview(int id);

        public List<GetTestModel> GetTest(int testId);
    }
}
