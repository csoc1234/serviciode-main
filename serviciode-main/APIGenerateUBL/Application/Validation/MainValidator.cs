using FluentValidation.Results;

namespace APIGenerateUBL.Application.Validation
{
    public class MainValidator
    {
        public static ResponseValidation Check(ValidationResult result, string? resultConcat = null)
        {
            ResponseValidation response = new ResponseValidation();

            try
            {
                if (!result.IsValid)
                {
                    string errormessages = GetMessage(result);

                    response = new ResponseValidation() { Code = 400, Message = errormessages };

                    if (!string.IsNullOrEmpty(resultConcat))
                    {
                        response.Message = string.Format("{0}; {1}", response.Message, resultConcat);
                    }
                }
                else if (!string.IsNullOrEmpty(resultConcat))
                {
                    response = new ResponseValidation() { Code = 400, Message = resultConcat };
                }
                else
                {
                    //Ha pasado las validaciones
                    response = new ResponseValidation() { Code = 200, Message = "", IsValid = true };
                }



            }
            catch (Exception ex)
            {

                response = new ResponseValidation { Code = 400, Message = "Error al momento de validar los datos de entrada" };
            }

            return response;
        }

        public static string GetMessage(ValidationResult result)
        {
            return string.Join("; ", result.Errors.Select(x => x.ErrorMessage));
        }
    }
}