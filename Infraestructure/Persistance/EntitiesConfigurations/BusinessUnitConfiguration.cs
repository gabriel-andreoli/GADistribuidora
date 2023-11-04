using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistance.EntitiesConfigurations
{
    public class BusinessUnitConfiguration : IEntityTypeConfiguration<BusinessUnit>
    {
        public void Configure(EntityTypeBuilder<BusinessUnit> builder)
        {
            
        }
    }
}
