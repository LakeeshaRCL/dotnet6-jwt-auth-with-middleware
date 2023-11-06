using JwtAuthenticationWithMiddlewares.Helpers.Requests.Auth;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;

namespace JwtAuthenticationWithMiddlewares.Services.AuthService
{
    public interface IAuthService
    {
       
        BaseResponse Authenticate(AuthenticateRequest request);
    }
}
