using APIComunicationDIAN.Application.Dto;
using APIComunicationDIAN.Domain.Enum;

namespace APIComunicationDIAN.Application.Interface
{
    public interface IDianSend
    {
        Task<DianResponseDto> PostTestSetAsyncSend(SendRequestDto request, EnvironmentEnum environment);

        Task<DianResponseDto> PostSyncSend(SendRequestDto sendRequest, EnvironmentEnum environment);
    }
}
