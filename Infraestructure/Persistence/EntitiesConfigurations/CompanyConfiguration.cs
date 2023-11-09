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
            builder.HasMany(u => u.Users).WithOne(c => c.Company).HasForeignKey(x => x.CompanyId).IsRequired();

            //Properties
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Phone).HasMaxLength(40);
        }
    }
}
