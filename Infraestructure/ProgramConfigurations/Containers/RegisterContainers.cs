using GADistribuidora.Domain.Handlers.Implementations;
using GADistribuidora.Domain.Handlers.Interfaces;
using GADistribuidora.Domain.Repositories.Implementations;
using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Domain.Services.Implementations;
using GADistribuidora.Domain.Services.Interfaces;
using GADistribuidora.Infraestructure.Persistence;

namespace GADistribuidora.Infraestructure.ProgramConfigurations.Containers
{
    public static class RegisterContainers
    {
        public static void AddContainers(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddScoped<INotificationHandler, NotificationHandler>();
        }
    }
}
