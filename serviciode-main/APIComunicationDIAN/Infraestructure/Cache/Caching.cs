using APIComunicationDIAN.Infraestructure.Interface;
using System.Runtime.Caching;

namespace APIComunicationDIAN.Infraestructure.Cache
{
    public class Caching : ICaching
    {
        private readonly IConfiguration _configuration;
        private MemoryCache _MemoryCache = new MemoryCache("CacheAPI");

        public Caching(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool TryGetValue(string key, out string value)
        {
            try
            {
                value = (string)_MemoryCache.Get(key);

                return value != null;
            }
            catch (Exception)
            {
                value = null;
                return false;
            }
        }

        public bool Set(string key, string value)
        {
            try
            {
                int hours = int.Parse(_configuration["CacheLocal:ExpireHours"]);

                _MemoryCache.Add(key, value, DateTimeOffset.Now.AddHours(hours));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
