using APIComunicationDIAN.Application.Dto;
using FluentValidation;

namespace APIComunicationDIAN.Application.Validation
{
    public class SendRequestValidator : AbstractValidator<SendRequestDto>
    {
        public SendRequestValidator()
        {
            RuleFor(x => x.nombreArchivo).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El Nombre de Archivo es Requerido")
                .NotEmpty().WithMessage("El Nombre de Archivo es Requerido")
                .Matches(@"^[a-zA-Z0-9.-]+$").WithMessage("El Nombre de Archivo tiene caracteres no validos");

            RuleFor(x => x.archivo).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El Archivo es Requerido")
                .NotEmpty().WithMessage("El Archivo es Requerido");

            RuleFor(x => x.hash).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El Hash es Requerido")
                .NotEmpty().WithMessage("El Hash es Requerido");

            RuleFor(x => x.sesion).Cascade(CascadeMode.Stop) 
                .NotNull().WithMessage("El Sesion es requerido")
                .NotEmpty().WithMessage("El Sesion es requerido")
                .Matches(@"^[a-zA-Z0-9-]+$").WithMessage("El Sesion tiene caracteres no validos")                
                .MinimumLength(0).WithMessage("Longitud no valida para el Sesion")
                .MaximumLength(100).WithMessage("Longitud no valida para el Sesion");

            RuleFor(x => x.cufe).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El CUFE es Requerido")
                .NotEmpty().WithMessage("El CUFE es Requerido")
                .Length(96, 96).WithMessage("El CUFE debe contener 96 caracteres")
                .Matches(@"^[a-zA-Z0-9]+$").WithMessage("El CUFE tiene caracteres no validos");
        }
    }
}
