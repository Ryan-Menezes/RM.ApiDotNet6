using FluentValidation;

namespace RM.ApiDotNet6.Application.DTOs.Validations
{
    public class PersonDTOValidator : AbstractValidator<PersonDTO>
    {
        public PersonDTOValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("O nome é obrigatório");

            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("O documento é obrigatório");

            RuleFor(x => x.Phone)
                .NotEmpty()
                .NotNull()
                .WithMessage("O celular é obrigatório");
        }
    }
}
