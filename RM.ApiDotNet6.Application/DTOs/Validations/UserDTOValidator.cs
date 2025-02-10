using FluentValidation;

namespace RM.ApiDotNet6.Application.DTOs.Validations
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage("O e-mail é obrigatório");

            RuleFor(x => x.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage("A senha é obrigatória");
        }
    }
}
