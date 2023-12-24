using System.Net.Mail;

namespace GADistribuidora.Presentation.Commands
{
    public class RegisterUserCommand
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Name { get; set; }
        public string? CompanyId { get; set; }
    }
}
