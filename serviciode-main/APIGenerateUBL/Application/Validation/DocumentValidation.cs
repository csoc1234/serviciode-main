using APIGenerateUBL.Application.Dto;
using FluentValidation;

namespace APIGenerateUBL.Application.Validation
{
    public class DocumentValidation : AbstractValidator<DocumentDtoRequest>
    {
        //private readonly IConfiguration _configuration;
        public DocumentValidation()
        {
            RuleFor(x => x.FacturaGeneral).Cascade(CascadeMode.Stop)
                        .NotNull().WithMessage("El documento es requerido")
                        .NotEmpty().WithMessage("El documento es requerido");
            // _configuration = configuration;
        }
    }
}
