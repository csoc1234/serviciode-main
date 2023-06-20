using FluentValidation;

namespace APIComunicationDIAN.Application.Validation
{
    public class CufeValidator : AbstractValidator<string>
    {
        public CufeValidator()
        {
            RuleFor(x => x).Cascade(CascadeMode.Stop)
              .Length(96, 96).WithMessage("El CUFE debe contener 96 caracteres")
              .Matches(@"^[a-zA-Z0-9]+$").WithMessage("El CUFE tiene caracteres no validos");
        }
    }
}
