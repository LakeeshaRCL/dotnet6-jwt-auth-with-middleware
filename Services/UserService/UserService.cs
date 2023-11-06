using JwtAuthenticationWithMiddlewares.DTOs;
using JwtAuthenticationWithMiddlewares.Helpers.Requests.User;
using JwtAuthenticationWithMiddlewares.Helpers.Responses;
using JwtAuthenticationWithMiddlewares.Helpers.Utils;
using JwtAuthenticationWithMiddlewares.Models;

namespace JwtAuthenticationWithMiddlewares.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext dbContext;

        public UserService(ApplicationDbContext dbContext)
        {

            this.dbContext = dbContext;

        }



        public BaseResponse CreateUser(CreateUserRequest request)
        {

            try
            {

                // check requested user name already exists
                UserModel? existingUser = dbContext.User.Where(u => u.username == request.username).FirstOrDefault();

                if (existingUser != null) {
                    return new BaseResponse { status_code = StatusCodes.Status400BadRequest, data = new MessageDTO("username already exist in the system") };
                }

                UserModel newUser = new UserModel();
                newUser.first_name = request.first_name;
                newUser.last_name = request.last_name;
                newUser.username = request.username;
                newUser.email = request.email;
                newUser.password = Supports.GenerateMD5(request.password);

                dbContext.User.Add(newUser);
                dbContext.SaveChanges();

                return new BaseResponse { status_code = StatusCodes.Status200OK, data = new MessageDTO("successfully saved the new user") };
            }
            catch (Exception ex)
            {

                return new BaseResponse { status_code = StatusCodes.Status500InternalServerError, data = new MessageDTO(ex.Message) } ;
            }

        }
    }
}
