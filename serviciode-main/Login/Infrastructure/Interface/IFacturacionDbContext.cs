using Login.Domain.Entity;
using Login.Infrastructure.Logger;

namespace Login.Infrastructure.Interface
{
    public interface IFacturacionDbContext
    {
        UserBase GetEnterpriseWithTokens(User enterprise, ILogAzure log);
    }
}
