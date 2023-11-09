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

        public List<string> VerifyCredentials() 
        {
            List<string> result = new List<string>();

            if (Password != ConfirmPassword)
                result.Add("As senhas não conferem, verifique os dados e tente novamente");

            if (Password.Length <= 4)
                result.Add("A senha deve conter 5 ou mais caracteres");

            try
            {
                MailAddress mailAddress = new MailAddress(Email);
            }
            catch (FormatException) 
            {
                result.Add("O endereço de email não é válido");
            }

            return result;
        }
    }
}
