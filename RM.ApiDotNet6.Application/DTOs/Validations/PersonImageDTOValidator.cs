using FluentValidation;

namespace RM.ApiDotNet6.Application.DTOs.Validations
{
    public class PersonImageDTOValidator : AbstractValidator<PersonImageDTO>
    {
        public PersonImageDTOValidator()
        {
            RuleFor(x => x.PersonId)
                .GreaterThan(0)
                .WithMessage("O id da pessoa deve ser maior que zero");

            RuleFor(x => x.Image)
                .NotEmpty()
                .NotNull()
                .WithMessage("A imagem é obrigatória");
        }
    }
}
