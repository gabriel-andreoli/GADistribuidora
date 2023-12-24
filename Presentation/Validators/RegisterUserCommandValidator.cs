using FluentValidation;
using GADistribuidora.Presentation.Commands;

namespace GADistribuidora.Presentation.Validators
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Password).NotEmpty().Equal(x => x.ConfirmPassword).WithMessage("As senhas não conferem, verifique os dados e tente novamente");
            RuleFor(x => x.Email).EmailAddress().WithMessage("O email é inválido");
            RuleFor(x => x.Password).MinimumLength(4).WithMessage("Sua senha deve conter mais caracteres, insira uma senha válida");
            RuleFor(x => x.Password).NotEmpty().Must(x => x.Any(char.IsUpper)).WithMessage("A sua senha deve conter pelo menos 1 caracter maiúsculo de A-Z");
        }
    }
}
