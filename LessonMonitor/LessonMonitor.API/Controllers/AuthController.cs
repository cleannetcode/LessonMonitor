using System.Threading.Tasks;
using LessonMonitor.API.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("registration")]
        public async Task SignUp(UserCredentials credentials)
        {

        }

        [HttpPost("login")]
        public async Task SignIn(UserCredentials credentials)
        {

        }
    }
}
