using APIComunicationDIAN.Application.Dto;
using APIComunicationDIAN.Domain.Enum;

namespace APIComunicationDIAN.Application.Interface
{
    public interface IDianStatus
    {
        Task<DianResponseDto> GetStatus(string cufe, EnvironmentEnum environment);
    }
}
