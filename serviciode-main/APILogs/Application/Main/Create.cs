using APILogs.Application.Dto;
using APILogs.Application.Interface;
using APILogs.Domain.Entity;
using APILogs.Domain.Interface;
using AutoMapper;

namespace APILogs.Application.Main
{
    public class Create : ICreate
    {
        private readonly IContextDomain _contextDomain;
        private readonly IMapper _mapper;

        public Create(IContextDomain contextDomain, IMapper mapper)
        {
            _contextDomain = contextDomain;
            _mapper = mapper;
        }

        public async Task<LogResponseDto> Register(LogRequestDto request)
        {
            try
            {
                //Validation
                if (request.Log == null)
                {
                    return new LogResponseDto
                    {
                        Code = 400,
                        Message = "Error Request vacio"
                    };
                }

                //Mapper Dto to Entity
                Logs logs = new();
                _mapper.Map(request.Log, logs);

                //Consuming Domain
                Logs result = await _contextDomain.Mongo(logs, request.Application, request.Frequency);

                if (result.Id != null)
                {
                    //Result
                    return new LogResponseDto
                    {
                        Id = result.Id,
                        Code = 200,
                        Message = "Registrado"
                    };
                }
                else
                {
                    return new LogResponseDto
                    {
                        Code = 500,
                        Message = "No guardado"
                    };
                }
            }
            catch (Exception ex)
            {
                return new LogResponseDto
                {
                    Code = 500,
                    Message = "Exception." + ex.Message
                };
            }
        }
    }
}
