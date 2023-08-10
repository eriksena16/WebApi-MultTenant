using Microsoft.AspNetCore.Mvc;

namespace WebApi_MultTenant.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        protected long ClientId { get; set; }

        public ApiControllerBase()
        {
            
        }
        public ApiControllerBase(IHttpContextAccessor httpContextAccessor)
        {
            var httpContext = httpContextAccessor.HttpContext;

            if (httpContext.Request.Headers.TryGetValue("ClientId", out var valorDoCabecalho))
            {
                ClientId = long.Parse(valorDoCabecalho);
            }
        }

    }
}
