using APIComunicationDIAN.Domain.Enum;
using ServiceDIAN;

namespace APIComunicationDIAN.Domain.Interface
{
    public interface IStatusDomain
    {
        Task<DianResponse> GetStatus(string cufe, EnvironmentEnum environment);
        Task<DianResponse> GetStatusZipAsync(string trackID, EnvironmentEnum environment);


    }
}
