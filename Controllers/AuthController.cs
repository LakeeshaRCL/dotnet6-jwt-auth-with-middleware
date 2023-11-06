using JwtAuthenticationWithMiddlewares.Helpers.Requests.Auth;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;
using JwtAuthenticationWithMiddlewares.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationWithMiddlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }



        [HttpPost("authenticate")]
        public BaseResponse Authenticate(AuthenticateRequest request)
        {
            return authService.Authenticate(request);
        }
    }
}
