using Microsoft.AspNetCore.Mvc;
using TestJWT.Models;
using BC = BCrypt.Net;

namespace TestJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();

        [HttpPost("register")]
        public ActionResult<User> Register(UserDto request)
        {
            string passwordHas = BC.BCrypt.HashPassword(request.Password);

            user.Username = request.Username;
            user.PasswordHash = passwordHas;

            return Ok(user);
        }
    }
}
