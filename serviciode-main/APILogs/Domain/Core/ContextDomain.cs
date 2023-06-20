using APILogs.Domain.Entity;
using APILogs.Domain.Interface;
using APILogs.Infrastucture.Interface;

namespace APILogs.Domain.Core
{
    public class ContextDomain : IContextDomain
    {
        private readonly IDbContextMongo _dbContextMongo;
        private readonly IConfiguration _configuration;

        public ContextDomain(IDbContextMongo dbContextMongo, IConfiguration configuration)
        {
            _dbContextMongo = dbContextMongo;
            _configuration = configuration;
        }

        public async Task<Logs> Mongo(Logs logs, string application, string frequency)
        {
            try
            {
                string collectionName = _configuration["Environment"] + application + Frequency.Get(frequency);
                Logs result = await _dbContextMongo.CreateAsync(logs, collectionName);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new Logs
                    {
                        Code = 500,
                    };
                }
            }
            catch (Exception ex)
            {
                return new Logs
                {
                    Code = 500,
                };
            }
        }
    }
}
