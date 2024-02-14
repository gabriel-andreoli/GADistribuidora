using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class WarehouseLotConfiguration : IEntityTypeConfiguration<WarehouseLot>
    {
        public void Configure(EntityTypeBuilder<WarehouseLot> builder)
        {
            builder.HasKey(wl => wl.Id);

            builder.HasMany(wl => wl.StockMovements).WithOne(wl => wl.WarehouseLot).HasForeignKey(wl => wl.WarehouseLotId).IsRequired();
        }
    }
}
