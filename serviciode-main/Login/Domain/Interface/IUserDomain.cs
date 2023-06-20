using Login.Domain.Entity;
using Login.Infrastructure.Logger;

namespace Login.Domain.Interface
{
    public interface IUserDomain
    {
        public TokenJwtUser Validate(User enterprise, ILogAzure log);
    }
}
