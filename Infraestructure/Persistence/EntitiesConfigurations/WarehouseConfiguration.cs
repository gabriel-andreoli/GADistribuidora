using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class WarehouseConfiguration : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder.HasKey(w => w.Id);

            builder.HasMany(w => w.WarehouseLots).WithOne(w => w.Warehouse).HasForeignKey(w => w.WarehouseId).IsRequired();
            builder.Property(w => w.Name).HasMaxLength(100);
        }
    }
}
