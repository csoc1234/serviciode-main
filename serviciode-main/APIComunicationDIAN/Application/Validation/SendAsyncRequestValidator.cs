using APIComunicationDIAN.Application.Dto;
using FluentValidation;

namespace APIComunicationDIAN.Application.Validation
{
    public class SendAsyncRequestValidator : SendRequestValidator
    {
        public SendAsyncRequestValidator()
        {
            RuleFor(x => x.testSetId).Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("El TestSetId es requerido")
                .NotEmpty().WithMessage("El TestSetId es requerido")
                .Matches(@"^[0-9a-f]{8}-[0-9a-f]{4}-4[0-9a-f]{3}-[89ab][0-9a-f]{3}-[0-9a-f]{12}$").WithMessage("El Sesion tiene un formato invalido")
                .MinimumLength(36).WithMessage("Longitud no valida para el TestSetId")
                .MaximumLength(36).WithMessage("Longitud no valida para el TestSetId");
        }
    }
}
