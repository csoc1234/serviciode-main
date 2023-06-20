namespace APITemplate.Application.Validation
{
    public class ValidatorByte
    {
        public static bool Validate(string file)
        {
            try
            {
                byte[] result = Convert.FromBase64String(file);

                if (result.Length > 0)
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ValidateFileSize(string file, int maxFileSizeInMB)
        {
            try
            {
                byte[] result = Convert.FromBase64String(file);

                if (result.Length <= (maxFileSizeInMB * 1024 * 1024))
                {
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
