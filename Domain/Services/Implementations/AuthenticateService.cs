using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.Services.Interfaces;
using GADistribuidora.Infraestructure.Persistance;
using GADistribuidora.Presentation.Commands;
using Microsoft.AspNetCore.Identity;
using System.Net.Mail;

namespace GADistribuidora.Domain.Services.Implementations
{
    public class AuthenticateService : ServiceBase, IAuthenticateService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthenticateService(SignInManager<User> signInManager, UserManager<User> userManager, IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterUser(RegisterUserCommand command)
        {
            var user = new User() { Email = command.Email, UserName = command.UserName };
            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
                throw new Exception("Erro, contate o suporte para atendimento");
            Commit();
        }
    }
}
