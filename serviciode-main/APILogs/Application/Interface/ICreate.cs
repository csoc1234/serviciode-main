using APILogs.Application.Dto;

namespace APILogs.Application.Interface
{
    public interface ICreate
    {
        Task<LogResponseDto> Register(LogRequestDto request);
    }
}
