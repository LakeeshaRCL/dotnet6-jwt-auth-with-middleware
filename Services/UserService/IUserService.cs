using JwtAuthenticationWithMiddlewares.Helpers.Requests.User;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;

namespace JwtAuthenticationWithMiddlewares.Services.UserService
{
    public interface IUserService
    {
        BaseResponse CreateUser(CreateUserRequest request);
    }
}
