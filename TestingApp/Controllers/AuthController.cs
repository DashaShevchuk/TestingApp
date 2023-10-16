using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestingApp.Data.EfContext;
using TestingApp.Data.Entities.AppUser;
using TestingApp.Data.Interfaces.User;
using TestingApp.Data.Model;
using TestingApp.Data.Services;

namespace TestingApp.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<DbUser> userManager;
        private readonly SignInManager<DbUser> signInManager;
        private readonly EfDbContext context;
        private readonly IJwtTokenService jwtTokenService;
        private readonly IUserQueries userQueries;
        public AuthController(EfDbContext Context,
                               UserManager<DbUser> UserManager,
                               SignInManager<DbUser> SigInManager,
                               IJwtTokenService JwtTokenService,
                               IUserQueries UserQueries)
        {
            userManager = UserManager;
            signInManager = SigInManager;
            context = Context;
            jwtTokenService = JwtTokenService;
            userQueries = UserQueries;
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Input all data");
            }
            var user = await userQueries.GetUserByEmail(model.Username);
            if (user == null)
            {
                return BadRequest("Wrong email adres");
            }
            var res = signInManager
                .PasswordSignInAsync(user, model.Password, false, false).Result;
            if (!res.Succeeded)
            {
                return BadRequest("Wrong password");
            }

            if (!await userManager.IsEmailConfirmedAsync(user))
            {
                return Unauthorized();
            }

            await signInManager.SignInAsync(user, isPersistent: false);

            var accessToken = jwtTokenService.CreateToken(user);
            var refreshToken = jwtTokenService.CreateRefreshToken(user);

            return Ok(new { token = accessToken, refreshToken });
        }
    }
}
