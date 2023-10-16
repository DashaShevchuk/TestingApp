using System.Collections.Generic;
using System.Linq;
using TestingApp.Data.Interfaces.Tests;
using TestingApp.Data.Model;

namespace TestingApp.Data.Services
{
    public class TestsService : ITestService
    {
        private readonly ITestsQueries testsQueries;

        public TestsService(ITestsQueries TestsQueries)
        {
            testsQueries = TestsQueries;
        }

        public TestCardModel GetAvailableTestPreview(int id)
        {
            return testsQueries.GetTestById(id);
        }

        public List<TestCardModel> GetAvailableTests()
        {
            return testsQueries.GetAvailableTests();
        }

        public List<GetTestModel> GetTest(int testId)
        {
            return testsQueries.GetTest(testId);
        }
    }
}
