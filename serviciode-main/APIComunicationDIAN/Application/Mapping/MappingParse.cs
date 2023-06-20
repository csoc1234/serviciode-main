using APIComunicationDIAN.Domain.Enum;

namespace APIComunicationDIAN.Application.Mapping
{
    public static class MappingParse
    {
        public static int GetCode(bool isvalid, string code)
        {
            return isvalid ? 200 : int.TryParse(code, out int codigo) ? codigo : 99;
        }

        public static string? GetMessage(string code, string message)
        {
            int.TryParse(code, out int codeInt);

            ErrorsDictionary.Errors.TryGetValue(codeInt, out string? errorMessage);

            return string.IsNullOrEmpty(errorMessage) ? "Error" : errorMessage;
        }

        public static List<string> GetDianErrors(string[] errorList)
        {
            List<string> list = new();

            if (errorList != null)
            {
                foreach (string row in errorList)
                {
                    if (row != null)
                    {
                        if (row.Contains("Notificación") || row.Contains("Notificacion"))
                        { }
                        else
                        {
                            list.Add(row);
                        }
                    }
                }
            }
            return list;
        }

        public static List<string> GetDianNotifications(string[] errorList)
        {
            List<string> list = new();

            if (errorList != null)
            {
                foreach (string row in errorList)
                {
                    if (row != null)
                    {
                        if (row.Contains("Notificación") || row.Contains("Notificacion"))
                        {
                            list.Add(row);
                        }
                    }
                }
            }
            return list;
        }
    }
}
