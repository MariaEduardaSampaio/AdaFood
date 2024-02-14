using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace AdaFood.Application.Filters
{
    public class CustomAuthoritazionFilter : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("Role", out var role);
            if (role != "Admin")
                throw new Exception("Usuário não tem acesso a essa rota.");
        }
    }
}
