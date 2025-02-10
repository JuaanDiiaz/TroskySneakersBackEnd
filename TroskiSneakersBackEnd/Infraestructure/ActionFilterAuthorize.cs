using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace TroskiSneakersBackEnd.Infraestructure
{
    public class ActionFilterAuthorize : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.HttpContext.Request.Path.Value!.Contains("Login"))
            {
                var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

                if (token == null)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                    return;
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadJwtToken(token);

                if (jwtToken == null || jwtToken.ValidTo < DateTime.UtcNow)
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                    return;
                }
            }
            await next();
        }
    }
}
