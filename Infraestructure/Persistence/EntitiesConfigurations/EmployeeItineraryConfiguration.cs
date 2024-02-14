using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class EmployeeItineraryConfiguration : IEntityTypeConfiguration<EmployeeItinerary>
    {
        public void Configure(EntityTypeBuilder<EmployeeItinerary> builder) => builder.HasKey(ei => ei.Id);
    }
}
