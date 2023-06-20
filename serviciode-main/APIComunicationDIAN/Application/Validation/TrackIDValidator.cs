using FluentValidation;

namespace APIComunicationDIAN.Application.Validation
{
    public class TrackIDValidator : AbstractValidator<string>
    {
        public TrackIDValidator()
        {
            RuleFor(x => x).Cascade(CascadeMode.Stop)
              .Length(36, 36).WithMessage("El TrackID debe contener 64 caracteres")
              .Matches(@"^[a-zA-Z0-9-]+$").WithMessage("El TrackID tiene caracteres no validos");
        }
    }
}
