using GADistribuidora.Domain.Entities;
using GADistribuidora.Infraestructure.Persistance.EntitiesConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection.Emit;

namespace GADistribuidora.Infraestructure.Persistance
{
    public class GADistribuidoraContext : IdentityDbContext<User, UserIdentityRole, Guid>
    {
        public GADistribuidoraContext(DbContextOptions<GADistribuidoraContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<BusinessUnit> BusinessUnities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
            builder.ApplyConfiguration(new BusinessUnitConfiguration());
        }
    }
}
