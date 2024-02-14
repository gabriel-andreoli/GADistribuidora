using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            //Relationships
            builder.HasKey(x => x.Id);
            builder.HasMany(c => c.Users).WithOne(c => c.Company).HasForeignKey(x => x.CompanyId).IsRequired();
            builder.HasMany(c => c.Clients).WithOne(c => c.Company).HasForeignKey(x => x.CompanyId).IsRequired();
            builder.HasMany(c => c.Warehouses).WithOne(c => c.Company).HasForeignKey(x => x.CompanyId).IsRequired();
            builder.HasMany(c => c.Products).WithOne(c => c.Company).HasForeignKey(x => x.CompanyId).IsRequired();
            builder.HasMany(c => c.Employees).WithOne(c => c.Company).HasForeignKey(x => x.CompanyId).IsRequired();
            builder.HasMany(c => c.Suppliers).WithOne(c => c.Company).HasForeignKey(x => x.CompanyId).IsRequired();
            builder.HasMany(c => c.ShippingCompanies).WithOne(c => c.Company).HasForeignKey(x => x.CompanyId).IsRequired();
            builder.HasMany(c => c.Vehicles).WithOne(c => c.Company).HasForeignKey(x => x.CompanyId).IsRequired();

            //Properties
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.OwnsOne(x => x.Address, addressBuilder =>
            {
                addressBuilder.Property(a => a.Country).HasMaxLength(35).HasColumnName("Country");
                addressBuilder.Property(a => a.State).HasMaxLength(35).HasColumnName("State");
                addressBuilder.Property(a => a.City).HasMaxLength(35).HasColumnName("City");
                addressBuilder.Property(a => a.Neighborhood).HasMaxLength(50).HasColumnName("Neighborhood");
                addressBuilder.Property(a => a.Street).HasMaxLength(255).HasColumnName("Street");
                addressBuilder.Property(a => a.BuildingNumber).HasColumnName("BuildingNumber");
                addressBuilder.Property(a => a.PostalCode).HasMaxLength(8).HasColumnName("PostalCode");
                addressBuilder.Property(a => a.Complement).HasMaxLength(255).HasColumnName("Complement");
            });

            builder.OwnsOne(x => x.ContactInfo, contactInfoBuilder => 
            {
                contactInfoBuilder.Property(ci => ci.AreaCode).HasMaxLength(4).HasColumnName("AreaCode");
                contactInfoBuilder.Property(ci => ci.Phone).HasMaxLength(20).HasColumnName("Phone");
                contactInfoBuilder.Property(ci => ci.CelPhone).HasMaxLength(20).HasColumnName("CelPhone");
                contactInfoBuilder.Property(ci => ci.Email).HasMaxLength(20).HasColumnName("Email");
            });
        }
    }
}
