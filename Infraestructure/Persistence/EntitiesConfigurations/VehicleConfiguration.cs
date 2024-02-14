using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasKey(v => v.Id);

            builder.Property(v => v.YearOfManufacture).HasMaxLength(4);
            builder.Property(v => v.Brand).HasMaxLength(30);
            builder.Property(v => v.LicensePlate).HasMaxLength(30);
        }
    }
}
