using System.Collections.Generic;
using System.Data;
using TestingApp.Data.Model;

namespace TestingApp.Data.Interfaces.Tests
{
    public interface ITestsQueries
    {
        List<TestCardModel> GetAvailableTests();

        TestCardModel GetTestById(int id);

        List<GetTestModel> GetTest(int testId);
    }
}
