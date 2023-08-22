using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApi_MultTenant.Context;

namespace WebApi_MultTenant.Config
{
    public static class CustomerDataContextExtensions
    {
        public static void AddCustomerDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(provider =>
            {
                var httpContext = provider.GetService<IHttpContextAccessor>();

                var clientSlug = httpContext.HttpContext.User.GetClientSlug();

                var connString = configuration.GetClientConnectionString(clientSlug);
                var opts = new DbContextOptionsBuilder<Contexto>();
                opts.UseSqlServer(connString, s => s.EnableRetryOnFailure());
                opts.EnableSensitiveDataLogging();

                return new Contexto(opts.Options);
            });
        }
        public static long GetAccountId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var accountId = principal.Claims.FirstOrDefault(c => c.Type == "lastAccountId").Value;
            return long.Parse(accountId);
        }
        public static string GetClientSlug(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {
                throw new ArgumentException(nameof(principal));
            }

            var slug = principal.Claims.FirstOrDefault(c => c.Type == "slug").Value;
            return slug;
        }
    }
}
