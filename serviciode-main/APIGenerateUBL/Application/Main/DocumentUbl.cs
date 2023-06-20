using APIGenerateUBL.Application.Dto;
using APIGenerateUBL.Application.Interface;
using APIGenerateUBL.Application.Validation;
using APIGenerateUBL.Domain.Entity;
using APIGenerateUBL.Domain.Interface;
using FluentValidation.Results;

namespace APIGenerateUBL.Application.Main
{
    public class DocumentUbl : IDocumentUbl
    {
        private readonly ICreateDomain _createDomain;
        private readonly IConfiguration _configuration;

        public DocumentUbl(ICreateDomain createDomain, IConfiguration configuration)
        {
            _createDomain = createDomain;
            _configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// 
        public ResponseDto Generate(DocumentDtoRequest request)
        {

            try
            {
                if (request == null)
                {
                    ResponseDto? resultValidate = new ResponseDto() { Code = 400, Message = "Bad Request" };
                    return resultValidate;
                }


                //Validaciones Fluent Validation
                DocumentValidation? validator = new DocumentValidation();

                ValidationResult resultDocument = validator.Validate(request);

                ResponseValidation resultValidation = MainValidator.Check(resultDocument);

                //Validation Result
                if (!resultValidation.IsValid)
                {
                    ResponseDto? resultbr = new ResponseDto() { Code = resultValidation.Code, Message = resultValidation.Message };
                    return resultbr;
                }

                XmlFile resultDomain = _createDomain.Generate(request.FacturaGeneral, request.Emisor);

                var result = new ResponseDto
                {
                    Code = resultDomain.Code,
                    Message = resultDomain.Message,
                    Xml = resultDomain.Xml
                };

                return result;
            }
            catch (Exception ex)
            {

                ResponseDto? response = new ResponseDto()
                {
                    Code = 500,
                    Message = "Error al intentar generar un evento"
                };


                return response;
            }
        }
    }
}
