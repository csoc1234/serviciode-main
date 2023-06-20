using APIComunicationDIAN.Application.Dto;
using APIComunicationDIAN.Application.Interface;
using APIComunicationDIAN.Application.Validation;
using APIComunicationDIAN.Domain.Core;
using APIComunicationDIAN.Domain.Enum;
using APIComunicationDIAN.Domain.Interface;
using AutoMapper;
using ServiceDIAN;

namespace APIComunicationDIAN.Application.Main
{
    public class DianStatusEnable : IDianStatusEnable
    {
        private readonly IStatusDomain _statusDomain;
        private readonly IMapper _mapper;

        public DianStatusEnable(IStatusDomain statusDomain, IMapper mapper)
        {
            _statusDomain = statusDomain;
            _mapper = mapper;
        }

        public async Task<DianResponseDto> GetStatusZip(string trackID, EnvironmentEnum environment)
        {
            try
            {
                //Fluent Validation
                DianResponseDto resultValidate = ValidateTrackID.Validate<DianResponseDto>(trackID);

                if (resultValidate != null)
                {
                    return resultValidate;
                }

                //Call Domain
                DianResponse result = await _statusDomain.GetStatusZipAsync (trackID, environment);

                //AutoMapper
                DianResponseDto responseDto = new();
                _mapper.Map(result, responseDto);

                return responseDto;
            }
            catch (Exception ex)
            {
                return new DianResponseDto() { Codigo = 500 };
            }
        }
    }
}
