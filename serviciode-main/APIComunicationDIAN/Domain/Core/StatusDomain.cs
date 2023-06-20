using APIComunicationDIAN.Domain.Enum;
using APIComunicationDIAN.Domain.Interface;
using APIComunicationDIAN.Infraestructure.Interface;
using ServiceDIAN;

namespace APIComunicationDIAN.Domain.Core
{
    public class StatusDomain : IStatusDomain
    {
        private readonly IGetStatus _getStatus;
        private readonly IGetStatusZip _getStatusZip;
        private IWcfDianCustomerServices _connectionProd;
        public StatusDomain(IGetStatus getStatus, IGetStatusZip getStatusZip)
        {
            _getStatus = getStatus;
            _getStatusZip = getStatusZip;
        }

        public async Task<DianResponse> GetStatusZipAsync(string trackID, EnvironmentEnum environment)
        {
            try
            {
                DianResponse[] result = await _getStatusZip.Get(trackID, environment);

                //nota: que el result sea 1
                if (result != null)
                {
                    if (result.Length > 0)
                    {
                        return result[0];
                    }
                    else
                    {
                        return new DianResponse
                        {
                            StatusCode = "500",
                            StatusMessage = "La respuesta es vacía"
                        };
                    }

                }
                else
                {
                    return new DianResponse
                    {
                        StatusCode = "500",
                        StatusMessage = "Error al consultar el CUFE"
                    };
                }
            }
            catch (Exception e)
            {
                return new DianResponse
                {
                    StatusCode = "500",
                    StatusMessage = "Se ha generado un error mientras se consultaba a la DIAN"
                };
            }
        }

        public async Task<DianResponse> GetStatus(string cufe, EnvironmentEnum environment)
        {
            try
            {
                DianResponse result = await _getStatus.Get(cufe, environment);

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return new DianResponse
                    {
                        StatusCode = "500",
                        StatusMessage = "Error al consultar el CUFE"
                    };
                }
            }
            catch (Exception e)
            {
                return new DianResponse
                {
                    StatusCode = "500",
                    StatusMessage = "Se ha generado un error mientras se consultaba a la DIAN"
                };
            }
        }
    }
}
