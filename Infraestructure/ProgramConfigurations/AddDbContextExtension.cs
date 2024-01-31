using GADistribuidora.Infraestructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace GADistribuidora.Infraestructure.ProgramConfigurations
{
    public static class AddDbContextExtension
    {
        public static void AddDbContext(this WebApplicationBuilder builder) 
        {
            var conn = builder.Configuration.GetConnectionString("PgConn");

            builder.Services.AddDbContext<GADistribuidoraContext>(o => o.UseNpgsql(conn));
        }
    }
}
