using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class ItineraryConfiguration : IEntityTypeConfiguration<Itinerary>
    {
        public void Configure(EntityTypeBuilder<Itinerary> builder)
        {
            builder.HasKey(i => i.Id);

            builder.HasMany(i => i.EmployeeItineraries).WithOne(i => i.Itinerary).HasForeignKey(i => i.ItineraryId).IsRequired();
            builder.HasOne(i => i.Vehicle).WithMany(i => i.Itineraries).HasForeignKey(i => i.VehicleId).IsRequired();
            builder.HasMany(i => i.RouteItineraries).WithOne(i => i.Itinerary).HasForeignKey(i => i.ItineraryId).IsRequired();
        }
    }
}
