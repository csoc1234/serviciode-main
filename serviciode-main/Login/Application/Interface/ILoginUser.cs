using Login.Application.Dto;

namespace Login.Application.Interface
{
    public interface ILoginUser
    {
        Task<TokenJwtDto> Login(LoginRequest request);
    }
}
