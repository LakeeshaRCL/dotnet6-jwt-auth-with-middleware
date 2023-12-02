using Microsoft.AspNetCore.Mvc.Filters;

namespace JwtAuthenticationWithMiddlewares.Attributes
{
    public class ModelStateValidateAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if(context.ModelState.IsValid)
            {
                Console.WriteLine("Model is valid and is in expected state"); 
            }
            else
            {
                Console.WriteLine("Model is invalid and is not in expected state");
            }
        }
    }
}
