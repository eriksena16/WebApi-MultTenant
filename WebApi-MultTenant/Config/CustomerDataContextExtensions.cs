using Microsoft.EntityFrameworkCore;
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

                // In this sample we are using a customer identifier as the firs segment in the url request
                // Ex: http://localhost:5000/clienta/contacts
                //     http://localhost:5000/clientb/contacts
                var clientSlug = httpContext.HttpContext.Request.Path.Value.Split("/", StringSplitOptions.RemoveEmptyEntries)[0];

                // If you need to perform any validation like if the customer exists
                // or if it has a valid subscription you can request a master context
                // and perform validations
                //var masterContext = provider.GetService<MasterDataContext>();

                var connString = configuration.GetClientConnectionString(clientSlug);
                var opts = new DbContextOptionsBuilder<Contexto>();
                opts.UseSqlServer(connString, s => s.EnableRetryOnFailure());
                opts.EnableSensitiveDataLogging();

                return new Contexto(opts.Options);
            });
        }
    }
}
