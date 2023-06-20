using APITemplate.Application.Dto;
using FluentValidation;

namespace APITemplate.Application.Validation
{
    public class TemplateSaveRequestDtoValidator : AbstractValidator<TemplateSaveRequestDto>
    {
        public TemplateSaveRequestDtoValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("El ProductId es requerido.")
                .NotNull().WithMessage("El ProductId es requerido.")
                .GreaterThan(0).WithMessage("El ProductId debe ser mayor que cero.")
                .LessThanOrEqualTo(99).WithMessage("El EnterpriseId debe tener máximo 2 dígitos.");

            RuleFor(x => x.CustomerId)
                .NotEmpty().WithMessage("El CustomerId es requerido.")
                .NotNull().WithMessage("El CustomerId es requerido.")
                .GreaterThan(0).WithMessage("El CustomerId debe ser mayor que cero.")
                .LessThanOrEqualTo(99999).WithMessage("El EnterpriseId debe tener máximo 5 dígitos.");

            RuleFor(x => x.NameTemplate)
               .NotNull().WithMessage("El Nombre de Template es requerido.")
               .NotEmpty().WithMessage("El Nombre de Template es requerido.")
               .Matches(@"[a-zA-Z0-9-]+$").WithMessage("El Nombre de Template tiene caracteres no válidos.")
               .MaximumLength(255).WithMessage("El Nombre de Template debe tener máximo 255 caracteres.");

            RuleFor(x => x.Source)
                .NotEmpty().WithMessage("El Source es requerido.")
                .NotNull().WithMessage("El Source es requerido.")
                .Must(x => ValidatorByte.Validate(x)).WithMessage("Error al leer el archivo")
                .Must(x => ValidatorByte.ValidateFileSize(x, 1)).WithMessage("El tamaño del archivo debe ser menor o igual a 5MB.");
        }
    }
}
