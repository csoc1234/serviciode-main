using System.Text;

namespace APIComunicationDIAN.Common
{
    public class String64
    {
        public static string Base64Decode(string base64EncodedData)
        {
            byte[] base64EncodedBytes;
            try
            {
                base64EncodedBytes = Convert.FromBase64String(base64EncodedData);

                string returnValue = UTF8Encoding.UTF8.GetString(base64EncodedBytes);

                return returnValue;
            }
            catch (Exception)
            {
                return "";
            }
        }

        public static string Base64Encode(string plainText)
        {
            byte[]? plainTextBytes = new byte[1];
            try
            {
                plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            }
            catch (Exception)
            {
            }
            return System.Convert.ToBase64String(plainTextBytes);
        }
    }
}
