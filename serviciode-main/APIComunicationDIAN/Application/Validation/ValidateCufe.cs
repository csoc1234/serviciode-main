using FluentValidation.Results;
using Newtonsoft.Json;

namespace APIComunicationDIAN.Application.Validation
{
    public class ValidateCufe
    {
        public static T? Validate<T>(string cufe)
        {
            CufeValidator validator = new CufeValidator();

            ValidationResult result = validator.Validate(cufe);

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
