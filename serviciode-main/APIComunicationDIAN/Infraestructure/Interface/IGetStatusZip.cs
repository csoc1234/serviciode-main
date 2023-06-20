using APIComunicationDIAN.Domain.Enum;
using ServiceDIAN;

namespace APIComunicationDIAN.Infraestructure.Interface
{
    public interface IGetStatusZip
    {
        Task<DianResponse[]> Get(string trackId, EnvironmentEnum environment);
    }
}
