using APITemplate.Common;
using APITemplate.Domain.Entity;

namespace APITemplate.Domain.Interface
{
    public interface ICreateDomain
    {
        Task<ResponseBase> Create(Template template);
    }
}
