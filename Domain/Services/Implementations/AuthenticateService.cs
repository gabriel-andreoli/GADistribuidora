using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.Handlers.Interfaces;
using GADistribuidora.Domain.Repositories.Interfaces;
using GADistribuidora.Domain.Services.Interfaces;
using GADistribuidora.Infraestructure.Persistence;
using GADistribuidora.Presentation.Commands;
using Microsoft.AspNetCore.Identity;
using System.Globalization;
using System.Net.Mail;

namespace GADistribuidora.Domain.Services.Implementations
{
    public class AuthenticateService : ServiceBase, IAuthenticateService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly INotificationHandler _notificationHandler;

        public AuthenticateService(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IUserRepository userRepository, 
            IUnitOfWork unitOfWork,
            INotificationHandler notificationHandler) : base(unitOfWork, notificationHandler)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsNoTrackingAsync(email);
            if (user is null) return false;
            var result = await _signInManager.PasswordSignInAsync(user.UserName, password, false, false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task RegisterUser(RegisterUserCommand command)
        {
            var emailExists = await _userRepository.GetByEmailAsNoTrackingAsync(command.Email);
            if (emailExists != null)
                AddNotification("O Email já está cadastrado, informe um válido ou entre em contato com o suporte.");

            var user = new User() { Email = command.Email, UserName = command.Email, Name = command.Name };
            user.GenerateId();
            if (command.CompanyId == null)
            {
                var newCompany = new Company(command.Email, $"Empresa {command.Name}");
                newCompany.GenerateId();
                user.Company = newCompany;
                user.Role = Enums.EUserRole.Admin;
            }
            else 
            {
                //TODO 20231108
                //var company = _companyRepository.GetById(command.CompanyId);
                //if (company == null)
                //    throw new ArgumentException("A empresa fornecida não existe");
                //user.Company = company;
            }
            var result = await _userManager.CreateAsync(user, command.Password);
            if (!result.Succeeded)
                AddNotification($"Error, {result.Errors.FirstOrDefault().Description}");
            if(!HasNotification())
                Commit();
        }
    }
}
