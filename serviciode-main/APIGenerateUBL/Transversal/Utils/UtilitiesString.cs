using System.Text;

namespace APIGenerateUBL.Transversal.Utils
{
    public static class UtilitiesString
    {
        public static DateTime? ConvertDateTimeNullable(string str)
        {
            str = str.Trim();
            if (string.IsNullOrWhiteSpace(str))
            {
                return (null);
            }
            else
            {
                DateTime decvalue;
                DateTime.TryParse(str, out decvalue);
                return (decvalue);
            }
        }
        public static decimal ConvertDecimal(string str)
        {
            str = str.Trim();
            decimal decvalue;
            decimal.TryParse(str, out decvalue);
            return (decvalue);
        }

        public static decimal? ConvertDecimalNullable(string str)
        {
            str = str.Trim();
            if (string.IsNullOrWhiteSpace(str))
            {
                return (null);
            }
            else
            {
                decimal decvalue;
                decimal.TryParse(str, out decvalue);
                return (decvalue);
            }
        }

        public static string Base64Decode(string base64EncodedData)
        {
            byte[] base64EncodedBytes;
            try
            {
                base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            }
            catch (Exception)
            {
                return ("");
            }
            return (Encoding.UTF8.GetString(base64EncodedBytes));
        }
    }
}
