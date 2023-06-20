using APIComunicationDIAN.Application.Dto;
using APIComunicationDIAN.Application.Interface;
using APIComunicationDIAN.Application.Validation;
using APIComunicationDIAN.Domain.Enum;
using APIComunicationDIAN.Domain.Interface;
using AutoMapper;

namespace APIComunicationDIAN.Application.Main
{
    public class DianStatus : IDianStatus
    {
        private readonly IStatusDomain _statusDomain;
        private readonly IMapper _mapper;


        public DianStatus(IStatusDomain statusDomain, IMapper mapper)
        {
            _statusDomain = statusDomain;
            _mapper = mapper;
        }

        public async Task<DianResponseDto> GetStatus(string cufe, EnvironmentEnum environment)
        {
            try
            {
                //Fluent Validation
                DianResponseDto resultValidate = ValidateCufe.Validate<DianResponseDto>(cufe);

                if (resultValidate != null)
                {
                    return resultValidate;
                }

                //Call Domain
                ServiceDIAN.DianResponse result = await _statusDomain.GetStatus(cufe, environment);

                //AutoMapper
                DianResponseDto responseDto = new();
                _mapper.Map(result, responseDto);

                return responseDto;
            }
            catch (Exception ex)
            {
                return new DianResponseDto() { Codigo = 500, Mensaje = "Error al momento de procesar la transaccion" };
            }
        }
    }
}
