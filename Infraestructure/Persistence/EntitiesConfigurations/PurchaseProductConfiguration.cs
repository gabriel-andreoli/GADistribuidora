using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class PurchaseProductConfiguration : IEntityTypeConfiguration<PurchaseProduct>
    {
        public void Configure(EntityTypeBuilder<PurchaseProduct> builder) => builder.HasKey(pp => pp.Id);
    }
}
