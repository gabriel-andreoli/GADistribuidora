using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasMany(i => i.RouteItineraries).WithOne(i => i.Invoice).HasForeignKey(i => i.InvoiceId).IsRequired();
            builder.HasMany(i => i.Payments).WithOne(i => i.Invoice).HasForeignKey(i => i.InvoiceId).IsRequired();
        }
    }
}
