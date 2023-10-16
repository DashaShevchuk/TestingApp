using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using TestingApp.Data.Interfaces.Tests;
using TestingApp.Data.Model;

namespace TestingApp.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ITestService testService;

        public UserController(ITestService TestService)
        {
            testService = TestService;
        }
        [HttpGet]
        [Route("get/available")]
        public IActionResult GetAvailableTests()
        {
            var tests = testService.GetAvailableTests();
            if (tests == null)
            {
                return BadRequest();
            }
            return Ok(tests);
        }
        [HttpPost]
        [Route("get/available/{testId}")]
        public IActionResult GetTestsPreview(int testId)
        {
            var test = testService.GetAvailableTestPreview(testId);
            if (test == null)
            {
                return BadRequest();
            }
            return Ok(test);
        }
        [HttpPost]
        [Route("{testId}")]
        public IActionResult GetTest(int testId)
        {
            var test = testService.GetTest(testId);
            if (test == null)
            {
                return BadRequest();
            }
            return Ok(test);
        }
    }
}
