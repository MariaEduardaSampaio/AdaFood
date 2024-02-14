using AdaFood.Application.Requests;
using System.Text.Json;

namespace AdaFood.Application.Middlewares
{
    public class ValidacaoEntregadorMiddleware
    {
        private readonly RequestDelegate _next;

        public ValidacaoEntregadorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            using (StreamReader reader = new StreamReader(context.Request.Body))
            {
                string requestBody = await reader.ReadToEndAsync();
                Console.WriteLine($"Request Body: {requestBody}");

                var request = JsonSerializer.Deserialize<CriarEntregadorRequest>(requestBody);
                Console.WriteLine($"Deserialized Request: {JsonSerializer.Serialize(request)}");

                await _next(context);
            }
        }
    }

    public static class ValidacaoEntregadorMiddlewareExtensions
    {
        public static IApplicationBuilder ValidateDeliveryManData(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ValidacaoEntregadorMiddleware>();
        }
    }
}