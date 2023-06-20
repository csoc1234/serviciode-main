using APILogs.Application.Dto;
using APILogs.Domain.Entity;
using AutoMapper;

namespace APILogs.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LogDto, Logs>();
        }
    }
}
