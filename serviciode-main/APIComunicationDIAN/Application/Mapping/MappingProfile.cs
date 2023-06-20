using APIComunicationDIAN.Application.Dto;
using AutoMapper;
using ServiceDIAN;

namespace APIComunicationDIAN.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //transform DianResponse to ResponseDianDto
            CreateMap<DianResponse, DianResponseDto>()
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => MappingParse.GetCode(src.IsValid, src.StatusCode)))
                //TODO Verificar casos planteado en comunicaciones DIAN
                .ForMember(dest => dest.Mensaje, opt => opt.MapFrom(src => MappingParse.GetMessage(src.StatusCode, src.StatusMessage)))
                .ForMember(dest => dest.ApplicationResponse, opt => opt.MapFrom(src => src.XmlBase64Bytes != null ? src.XmlBase64Bytes : null))
                .ForMember(dest => dest.Entregado, opt => opt.MapFrom(src => !String.IsNullOrWhiteSpace(src.XmlDocumentKey)))
                .ForMember(dest => dest.EstatusCodigo, opt => opt.MapFrom(src => src.StatusCode))
                .ForMember(dest => dest.EstatusDescripcion, opt => opt.MapFrom(src => src.StatusDescription))
                .ForMember(dest => dest.EstatusMensaje, opt => opt.MapFrom(src => src.StatusMessage))
                .ForMember(dest => dest.EsValido, opt => opt.MapFrom(src => src.IsValid))
                .ForMember(dest => dest.NombreArchivo, opt => opt.MapFrom(src => src.XmlFileName))
                .ForMember(dest => dest.Sesion, opt => opt.MapFrom(src => Guid.NewGuid()))
                .ForMember(dest => dest.TrackID, opt => opt.MapFrom(src => src.XmlDocumentKey))
                .ForMember(dest => dest.UUID, opt => opt.MapFrom(src => src.XmlDocumentKey))
                .ForMember(dest => dest.DIANFechaHoraRespuesta, opt => opt.MapFrom(src => DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dest => dest.DIANErrores, opt => opt.MapFrom(src => MappingParse.GetDianErrors(src.ErrorMessage)))
                .ForMember(dest => dest.DIANNotificaciones, opt => opt.MapFrom(src => MappingParse.GetDianNotifications(src.ErrorMessage)));

            //transform UploadDocumentResponse to ResponseDianDto
            CreateMap<UploadDocumentResponse, DianResponseDto>()
                .ForMember(dest => dest.TrackID, opt => opt.MapFrom(src => src.ZipKey))
                .ForMember(dest => dest.UUID, opt => opt.MapFrom(src => src.ErrorMessageList[0].DocumentKey))
                .ForMember(dest => dest.Mensaje, opt => opt.MapFrom(src => MappingParse.GetMessage(src.ErrorMessageList[0].SenderCode, src.ErrorMessageList[0].ProcessedMessage)))
                .ForMember(dest => dest.Codigo, opt => opt.MapFrom(src => MappingParse.GetCode(true, src.ErrorMessageList[0].SenderCode)))
                .ForMember(dest => dest.EsValido, opt => opt.MapFrom(src => src.ErrorMessageList[0].Success))
                .ForMember(dest => dest.NombreArchivo, opt => opt.MapFrom(src => src.ErrorMessageList[0].XmlFileName));
        }
    }
}
