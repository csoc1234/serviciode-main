using APIComunicationDIAN.Domain.Enum;
using ServiceDIAN;

namespace APIComunicationDIAN.Infraestructure.DianConnection
{
    public interface IDianClient
    {
        IWcfDianCustomerServices Connection(EnvironmentEnum environment);
    }
}
