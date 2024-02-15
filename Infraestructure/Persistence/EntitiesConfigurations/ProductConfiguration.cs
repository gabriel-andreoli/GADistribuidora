using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasMany(p => p.ProductOrders).WithOne(p => p.Product).HasForeignKey(p => p.ProductId).IsRequired();
            builder.HasMany(p => p.Lots).WithOne(p  => p.Product).HasForeignKey(p => p.ProductId).IsRequired();
            builder.HasMany(p => p.PurchaseProducts).WithOne(p => p.Product).HasForeignKey(p => p.ProductId).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(150);
        }
    }
}
