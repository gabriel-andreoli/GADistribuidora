using GADistribuidora.Presentation.Commands;

namespace GADistribuidora.Domain.Services.Interfaces
{
    public interface IAuthenticateService
    {
        Task<bool> Authenticate(string email, string password);
        Task RegisterUser(RegisterUserCommand command);
        Task Logout();
    }
}
