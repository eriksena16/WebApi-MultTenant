using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Entities;

namespace Server.Data
{
    public class AspNetIdentityDbContext : IdentityDbContext<Users>
    {
        public AspNetIdentityDbContext(DbContextOptions<AspNetIdentityDbContext> options)
          : base(options)
        {
        }
    }
}
