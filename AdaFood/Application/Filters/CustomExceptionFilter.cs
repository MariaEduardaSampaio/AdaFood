using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AdaFood.Application.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 400;

            var result = new ObjectResult("Ocorreu um erro ao processar a solicitação :( Tente novamente!")
            {
                StatusCode = context.HttpContext.Response.StatusCode
            };

            context.Result = result;
        }
    }
}
