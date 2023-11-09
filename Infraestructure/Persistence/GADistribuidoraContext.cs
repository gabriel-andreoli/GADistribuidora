using GADistribuidora.Domain.Entities;
using GADistribuidora.Infraestructure.Persistence.EntitiesConfigurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection.Emit;

namespace GADistribuidora.Infraestructure.Persistence
{
    public class GADistribuidoraContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public GADistribuidoraContext(DbContextOptions<GADistribuidoraContext> options) : base(options) { }

        public override DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            foreach (var relationship in builder.Model.GetEntityTypes()
            .SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CompanyConfiguration());
        }
    }
}
