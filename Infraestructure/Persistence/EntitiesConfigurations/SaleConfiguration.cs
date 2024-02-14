using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasKey(s => s.Id);

            builder.HasOne(s => s.Invoice).WithOne(s => s.Sale).HasForeignKey<Sale>(x => x.InvoiceId).IsRequired();
            builder.HasOne(s => s.Order).WithOne(s => s.Sale).HasForeignKey<Sale>(x => x.OrderId).IsRequired();
        }
    }
}
