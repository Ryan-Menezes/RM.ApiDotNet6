using FluentValidation;

namespace RM.ApiDotNet6.Application.DTOs.Validations
{
    public class PurchaseDTOValidator : AbstractValidator<PurchaseDTO>
    {
        public PurchaseDTOValidator()
        {
            RuleFor(x => x.CodErp)
                .NotEmpty()
                .NotNull()
                .WithMessage("O CodErp é obrigatório");

            RuleFor(x => x.Document)
                .NotEmpty()
                .NotNull()
                .WithMessage("O documento é obrigatório");
        }
    }
}
