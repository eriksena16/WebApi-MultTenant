using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi_MultTenant.Model;

namespace WebApi_MultTenant.Data.Mappings
{
    public class ContaMap : IEntityTypeConfiguration<Conta>
    {
        public void Configure(EntityTypeBuilder<Conta> builder)
        {
            builder.Property(c => c.Nome)
             .IsRequired(true)
             .HasMaxLength(100)
             .IsUnicode(false);

            builder.HasOne(c => c.Cliente)
                .WithOne(c => c.Conta)
                .HasForeignKey<Conta>(c => c.ClienteId);

        }
    }
}
