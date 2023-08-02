using Microsoft.EntityFrameworkCore;
using WebApi_MultTenant.Model;

namespace WebApi_MultTenant.Context
{
    public class ContextoMaster : DbContext
    {
        public ContextoMaster(DbContextOptions<ContextoMaster> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
    }
}
