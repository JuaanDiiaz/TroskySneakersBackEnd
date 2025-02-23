using Microsoft.AspNetCore.Mvc.Filters;

namespace TroskiSneakersBackEnd.Infraestructure
{
    public class ModelStateValidatorFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {

                return;
            }
            _ = await next();
        }
    } 
}
