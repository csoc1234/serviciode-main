using APIComunicationDIAN.Application.Dto;
using APIComunicationDIAN.Application.Interface;
using APIComunicationDIAN.Application.Validation;
using APIComunicationDIAN.Domain.Enum;
using APIComunicationDIAN.Domain.Interface;
using AutoMapper;
using ServiceDIAN;

namespace APIComunicationDIAN.Application.Main
{
    public class DianSend : IDianSend
    {
        private readonly ISendDomain _sendDomain;
        private readonly IMapper _mapper;

        public DianSend(ISendDomain sendDomain, IMapper mapper)
        {
            _sendDomain = sendDomain;
            _mapper = mapper;
        }

        public async Task<DianResponseDto> PostTestSetAsyncSend(SendRequestDto sendRequest, EnvironmentEnum environment)
        {
            try
            {
                //Fluent Validation
                DianResponseDto resultValidate = ValidateSendAsyncRequest.Validate<DianResponseDto>(sendRequest);

                if (resultValidate != null)
                {
                    return resultValidate;
                }

                //Call Domain
                UploadDocumentResponse result = await _sendDomain.SendAsync(sendRequest.nombreArchivo, sendRequest.archivo, sendRequest.testSetId, environment);

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

        public async Task<DianResponseDto> PostSyncSend(SendRequestDto sendRequest, EnvironmentEnum environment)
        {
            try
            {
                //Fluent Validation
                DianResponseDto resultValidate = ValidateSendSyncRequest.Validate<DianResponseDto>(sendRequest);

                if (resultValidate != null)
                {
                    return resultValidate;
                }

                //Call Domain
                DianResponse result = await _sendDomain.SendBill(sendRequest.nombreArchivo, sendRequest.archivo, environment);

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

