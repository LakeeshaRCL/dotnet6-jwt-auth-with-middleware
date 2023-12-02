using JwtAuthenticationWithMiddlewares.Attributes;
using JwtAuthenticationWithMiddlewares.Helpers.Requests.User;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;
using JwtAuthenticationWithMiddlewares.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthenticationWithMiddlewares.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService; 
        }




        [HttpPost("createUser")]
        public BaseResponse CreateUser(CreateUserRequest request)
        {
            return userService.CreateUser(request);
        }


    }
}
