using ERP.Services.DTO;
using FluentValidation;

namespace ERP.Services.Validators
{
    public class CurrencyValidator : AbstractValidator<ManipulateCurrencyDto>
    {
        public CurrencyValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Укажите имя");
            RuleFor(x => x.CharacterCode).NotEmpty().WithMessage("Укажите код валюты");
            RuleFor(x => x.NumericCode).NotEmpty().WithMessage("Укажите код валюты");
        }
    }
}