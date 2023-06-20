using APIComunicationDIAN.Domain.Enum;
using ServiceDIAN;

namespace APIComunicationDIAN.Infraestructure.Interface
{
    public interface IGetStatus
    {
        Task<DianResponse> Get(string cufe, EnvironmentEnum environment);

    }
}
