using Login.Domain.Entity;

namespace Login.Domain.Interface
{
    public interface ITokenJwt
    {
        TokenJwtUser GetToken(UserBase enterprise);
    }
}
