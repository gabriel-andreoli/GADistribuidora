using GADistribuidora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(c => c.Orders).WithOne(c => c.Client).HasForeignKey(c => c.ClientId).IsRequired();

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
