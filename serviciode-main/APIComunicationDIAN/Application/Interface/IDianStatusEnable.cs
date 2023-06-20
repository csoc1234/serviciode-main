using APIComunicationDIAN.Application.Dto;
using APIComunicationDIAN.Domain.Enum;

namespace APIComunicationDIAN.Application.Interface
{
    public interface IDianStatusEnable
    {
        Task<DianResponseDto> GetStatusZip(string trackID, EnvironmentEnum environment);
    }
}
