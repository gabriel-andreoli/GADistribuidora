using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class RouteItineraryConfiguration : IEntityTypeConfiguration<RouteItinerary>
    {
        public void Configure(EntityTypeBuilder<RouteItinerary> builder)
        {
            builder.HasKey(ri => ri.Id);
            builder.Property(ri => ri.Observations).HasMaxLength(255);
        }
    }
}
