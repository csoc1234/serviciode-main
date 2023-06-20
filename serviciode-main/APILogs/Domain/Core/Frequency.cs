namespace APILogs.Domain.Core
{
    public static class Frequency
    {
        public static string Get(string key)
        {
            return key?.ToLower() switch
            {
                "d" => DateTime.UtcNow.ToString("yyyyMMdd"),
                "m" => DateTime.UtcNow.ToString("yyyyMM"),
                "y" => DateTime.UtcNow.ToString("yyyy"),
                _ => DateTime.UtcNow.ToString("yyyyMM"),
            };
        }
    }
}
