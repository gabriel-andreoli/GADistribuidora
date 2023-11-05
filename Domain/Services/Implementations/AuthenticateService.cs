using GADistribuidora.Domain.Entities;
using GADistribuidora.Domain.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace GADistribuidora.Domain.Services.Implementations
{
    public class AuthenticateService : IAuthenticateService
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthenticateService(SignInManager<User> signInManager, UserManager<User> userManager)
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

        public async Task<bool> RegisterUser(string email, string password)
        {
            var user = new User() { Email = email };
            var result = await _userManager.CreateAsync(user, password);
            if (result.Succeeded)
                await _signInManager.SignInAsync(user, isPersistent: false);
            return result.Succeeded;
        }
    }
}
