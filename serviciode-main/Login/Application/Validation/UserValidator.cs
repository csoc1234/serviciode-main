using FluentValidation;
using Login.Application.Dto;

namespace TFHKA.Login.Application.Validations
{
    public class UserValidator : AbstractValidator<LoginRequest>
    {
        public UserValidator()
        {
            RuleFor(x => x.User).Cascade(CascadeMode.Stop)
                 .NotNull().WithMessage("El usuario es requerido")
                 .NotEmpty().WithMessage("El usuario es requerido")
                 .Matches(@"^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[8|9aAbB][0-9a-f]{3}-[0-9a-f]{12}$").WithMessage("El usuario tiene un formato invalido");

            RuleFor(x => x.Password).Cascade(CascadeMode.Stop)
                  .NotNull().WithMessage("La contraseña es requerido")
                  .NotEmpty().WithMessage("La contraseña es requerido")
                  .Matches(@"^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[8|9aAbB][0-9a-f]{3}-[0-9a-f]{12}$").WithMessage("La contraseña tiene un formato invalido");
        }
    }
}
