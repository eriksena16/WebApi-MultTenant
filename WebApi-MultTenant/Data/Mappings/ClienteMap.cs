using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi_MultTenant.Model;

namespace WebApi_MultTenant.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.Property(c => c.Nome)
           .IsRequired(true)
           .HasMaxLength(100)
           .IsUnicode(false);
        }
    }
}
