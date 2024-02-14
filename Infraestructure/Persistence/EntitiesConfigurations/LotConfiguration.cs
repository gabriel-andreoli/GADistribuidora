using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class LotConfiguration : IEntityTypeConfiguration<Lot>
    {
        public void Configure(EntityTypeBuilder<Lot> builder)
        {
            builder.HasKey(l => l.Id);

            builder.HasMany(l => l.WarehouseLots).WithOne(l => l.Lot).HasForeignKey(l => l.LotId).IsRequired();
            builder.Property(l => l.Nr_Lot).HasMaxLength(20);
        }
    }
}
