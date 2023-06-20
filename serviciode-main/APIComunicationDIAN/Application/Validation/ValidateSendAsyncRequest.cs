using APIComunicationDIAN.Application.Dto;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace APIComunicationDIAN.Application.Validation
{
    public class ValidateSendAsyncRequest
    {
        public static T? Validate<T>(SendRequestDto sendRequest)
        {
            SendAsyncRequestValidator validator = new SendAsyncRequestValidator();
            
            ValidationResult result = validator.Validate(sendRequest);

            if (!result.IsValid)
            {
                var resultError = new
                {
                    codigo = 400,
                    mensaje = result.Errors[0].ErrorMessage,
                    resultado = "Error"
                };

                string json = JsonConvert.SerializeObject(resultError);
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }
    }
}
