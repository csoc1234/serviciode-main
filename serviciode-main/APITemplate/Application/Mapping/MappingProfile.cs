using APITemplate.Application.Dto;
using APITemplate.Domain.Entity;
using AutoMapper;

namespace APITemplate.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TemplateSaveRequestDto, Template>()
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => Convert.FromBase64String(src.Source)));
        }
    }
}
