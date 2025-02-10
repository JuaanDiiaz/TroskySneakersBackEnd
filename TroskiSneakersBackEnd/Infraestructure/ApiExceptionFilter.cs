using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using TroskiSneakersBackEnd.Models;

namespace TroskiSneakersBackEnd.Infraestructure
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override async Task OnExceptionAsync(ExceptionContext context)
        {
            Console.WriteLine(context.Exception.Message);
            context.Result = new OkObjectResult(new Response()
            {
                Message = context.Exception.Message,
                Success = false,
                Data = null
            });
            return;
        }
    }
}
