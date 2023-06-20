using APIComunicationDIAN.Domain.Enum;
using ServiceDIAN;

namespace APIComunicationDIAN.Infraestructure.Interface
{
    public interface ISendBillSync
    {
        Task<DianResponse> Send(string namefile, byte[] contentFile, EnvironmentEnum environment);
    }
}
