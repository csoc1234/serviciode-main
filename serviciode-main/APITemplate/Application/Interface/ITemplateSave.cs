using APITemplate.Application.Dto;
using APITemplate.Common;

namespace APITemplate.Application.Interface
{
    public interface ITemplateSave
    {
        Task<ResponseBase> Save(TemplateSaveRequestDto request);
    }
}
