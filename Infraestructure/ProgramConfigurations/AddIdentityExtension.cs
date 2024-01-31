using GADistribuidora.Domain.Entities;
using GADistribuidora.Infraestructure.Persistence;
using Microsoft.AspNetCore.Identity;

namespace GADistribuidora.Infraestructure.ProgramConfigurations
{
    public static class AddIdentityExtension
    {
        public static void AddIdentity(this WebApplicationBuilder builder) 
        {

            builder.Services.AddIdentity<User, IdentityRole<Guid>>()
                        .AddEntityFrameworkStores<GADistribuidoraContext>()
                        .AddDefaultTokenProviders();
        }
    }
}
