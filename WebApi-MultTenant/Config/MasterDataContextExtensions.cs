using Microsoft.EntityFrameworkCore;
using WebApi_MultTenant.Context;

namespace WebApi_MultTenant.Config
{
    public static class MasterDataContextExtensions
    {
        public static void AddMasterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ContextoConnection' not found.");

            services.AddDbContext<ContextoMaster>(options =>
                                options.UseSqlServer(connectionString));

            //services.AddDbContext<Contexto>(options =>
            //                    options.UseSqlServer(connectionString));
        }
    }
}
