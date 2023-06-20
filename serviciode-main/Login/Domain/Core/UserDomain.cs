using Login.Domain.Entity;
using Login.Domain.Interface;
using Login.Infrastructure.Interface;
using Login.Infrastructure.Logger;
using Newtonsoft.Json;
using System.Reflection;

namespace TFHKA.Login.Domain.Core
{
    public class UserDomain : IUserDomain
    {
        private readonly IFacturacionDbContext _dbContext;
        private readonly ITokenJwt _tokenJwt;

        public UserDomain(IFacturacionDbContext dbContext, ITokenJwt tokenJwt)
        {
            _dbContext = dbContext;
            _tokenJwt = tokenJwt;
        }

        public TokenJwtUser Validate(User enterprise, ILogAzure log)
        {
            try
            {
                log.WriteComment(MethodBase.GetCurrentMethod().Name, "Inicio de proceso", LevelMsn.Info);

                //Consulta SQL
                UserBase result = _dbContext.GetEnterpriseWithTokens(enterprise, log);

                if (result != null)
                {
                    //Generacion Token
                    TokenJwtUser token = _tokenJwt.GetToken(result);

                    return token;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                log.WriteComment(MethodBase.GetCurrentMethod().Name, JsonConvert.SerializeObject(ex), LevelMsn.Error);

                return null;
            }
        }
    }
}
