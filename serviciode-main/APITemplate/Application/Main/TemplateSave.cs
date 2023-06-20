using APITemplate.Application.Dto;
using APITemplate.Application.Interface;
using APITemplate.Application.Validation;
using APITemplate.Common;
using APITemplate.Domain.Entity;
using APITemplate.Domain.Interface;
using AutoMapper;
using FluentValidation.Results;

namespace APITemplate.Application.Main
{
    public class TemplateSave : ITemplateSave
    {
        private readonly ICreateDomain _createDomain;
        private readonly IMapper _mapper;

        public TemplateSave(ICreateDomain createDomain, IMapper mapper)
        {
            _createDomain = createDomain;
            _mapper = mapper;
        }

        public async Task<ResponseBase> Save(TemplateSaveRequestDto request)
        {
            try
            {
                //Fluent Validation
                TemplateSaveRequestDtoValidator validator = new();

                ValidationResult validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return new ResponseBase
                    {
                        Code = 400,
                        Message = validationResult.Errors[0].ErrorMessage
                    };
                }

                //AutoMapper
                Template template = new();
                _mapper.Map(request, template);

                //Call Domain
                ResponseBase result = await _createDomain.Create(template);

                return result;

            }
            catch (Exception ex)
            {
                return new ResponseBase
                {
                    Code = 500,
                    Message = "Se ha producido un error durante la transaccion"
                };
            }
        }
    }
}
