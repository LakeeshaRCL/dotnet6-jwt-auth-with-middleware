using JwtAuthenticationWithMiddlewares.Helpers.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Data;

namespace JwtAuthenticationWithMiddlewares.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private long userId {  get; }


        // constructor
        public AuthorizeAttribute()
        {
            
        }


        public async void onAuthorization(AuthorizationFilterContext filterContext) {

            Console.WriteLine("Filter context from authorize attribute");
            Console.WriteLine(filterContext.HttpContext.Request.Host);


            filterContext.Result = new JsonResult(new { satatus = 400 }) { StatusCode = StatusCodes.Status401Unauthorized};
        }


        public async void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                bool IsAuthenticated = true;
                string message = "";

            

                if (!IsAuthenticated)
                {
                    var data = new
                    {
                        message = message == "" ? "Unauthorized" : message
                    };

                    var resp = new BaseResponse()
                    {
                        status_code = StatusCodes.Status401Unauthorized,
                        data = data
                    };

                    context.Result = new JsonResult(resp) { StatusCode = StatusCodes.Status401Unauthorized };
                }
            }
            catch (Exception)
            {

                var data = new
                {
                    message = "Unauthorized"
                };

                var resp = new BaseResponse()
                {
                    status_code = StatusCodes.Status401Unauthorized,
                    data = data
                };

                context.Result = new JsonResult(resp) { StatusCode = StatusCodes.Status401Unauthorized };
            }
        }

    }
}
