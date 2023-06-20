using FluentValidation.Results;
using Newtonsoft.Json;

namespace APIComunicationDIAN.Application.Validation
{
    public class ValidateTrackID
    {
        public static T? Validate<T>(string trackID)
        {
            TrackIDValidator validator = new TrackIDValidator();

            ValidationResult result = validator.Validate(trackID);

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
