using JwtAuthenticationWithMiddlewares.DTOs;
using JwtAuthenticationWithMiddlewares.Helpers.Requests.Auth;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;
using JwtAuthenticationWithMiddlewares.Helpers.Utils;
using JwtAuthenticationWithMiddlewares.Models;

namespace JwtAuthenticationWithMiddlewares.Services.AuthService
{
    public class AuthService : IAuthService
    {

        private readonly ApplicationDbContext dbContext;

        public AuthService(ApplicationDbContext dbContext)
        {   
            this.dbContext = dbContext;
        }


        //Token authentication method
        public BaseResponse Authenticate(AuthenticateRequest request)
        {
            try
            {
                UserModel? user = dbContext.User.Where(u => u.username == request.username).FirstOrDefault();    
                if (user == null)
                {
                    return new BaseResponse(StatusCodes.Status401Unauthorized, new MessageDTO("Invalid username or password"));
                }
                // get password in MD5
                string md5Password = Supports.GenerateMD5(request.password);
                // match password
                if(user.password == md5Password)
                {
                    // generate jwt
                    string jwt = JwtUtils.GenerateJwtToken(user);

                    // save token in login details
                    LoginDetailModel? loginDetail = dbContext.LoginDetails.Where(ld => ld.user_id == user.id).FirstOrDefault();

                    if(loginDetail == null)
                    {
                        loginDetail = new LoginDetailModel();
                        loginDetail.user_id = user.id;
                        loginDetail.token = jwt;

                        dbContext.LoginDetails.Add(loginDetail);
                        
                    }
                    else
                    {
                        loginDetail.token = jwt;
                        
                    }

                    dbContext.SaveChanges();

                    return new BaseResponse(StatusCodes.Status200OK, new {token = jwt});
                }
                else {
                    return new BaseResponse(StatusCodes.Status401Unauthorized, new MessageDTO("Invalid username or password"));
                }


            }
            catch (Exception ex)
            {

                return new BaseResponse { status_code = StatusCodes.Status500InternalServerError, data = new MessageDTO(ex.Message) };
            }
        }
    }
}
