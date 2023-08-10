using Microsoft.EntityFrameworkCore;
using WebApi_MultTenant.Model;

namespace WebApi_MultTenant.Context
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) 
            : base(options)
        {
        }

       
        public DbSet<Produto> Produtos { get; set; }
    }
}
