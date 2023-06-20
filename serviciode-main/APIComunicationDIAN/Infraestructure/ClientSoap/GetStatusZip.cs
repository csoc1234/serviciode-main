using APIComunicationDIAN.Domain.Enum;
using APIComunicationDIAN.Domain.Helper;
using APIComunicationDIAN.Infraestructure.DianConnection;
using APIComunicationDIAN.Infraestructure.Interface;
using ServiceDIAN;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;
using System.ServiceModel;

namespace APIComunicationDIAN.Infraestructure.ClientSoap
{
    public class GetStatusZip : IGetStatusZip
    {
        private readonly IDianClient _dianClient;
        private InspectorBehavior _inspector;
        private IWcfDianCustomerServices _connectionHab;
        private IWcfDianCustomerServices _connectionProd;


        public GetStatusZip(IDianClient dianClient)
        {
            _dianClient = dianClient;
            _connectionHab = _dianClient.Connection(EnvironmentEnum.Habilitation);
            _connectionProd = _dianClient.Connection(EnvironmentEnum.Production);
        }

        public async Task<DianResponse[]> Get(string trackId, EnvironmentEnum environment)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            try
            {
                DianResponse[] result;

                //_inspector = new InspectorBehavior();
                //connection.Endpoint.EndpointBehaviors.Add(_inspector);
                if (environment == EnvironmentEnum.Production)
                {
                    result = await _connectionProd.GetStatusZipAsync(trackId);
                }
                else
                {
                    result = await _connectionHab.GetStatusZipAsync(trackId);
                }

                //string requestXml = _inspector.LastRequestXML;
                //string responseXml = _inspector.LastResponseXML;

                stopwatch.Stop();
                //log
                return result;
            }
            catch (CryptographicException ex)
            {
                stopwatch.Stop();

                DianResponse[] result = new DianResponse[1];
                result[0] = new DianResponse
                {
                    StatusCode = "500",
                    StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return result;
            }
            catch (TimeoutException ex)
            {
                DianResponse[] result = new DianResponse[1];
                result[0] = new DianResponse
                {
                    StatusCode = "500",
                    StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return result;
            }
            catch (WebException ex)
            {
                DianResponse[] result = new DianResponse[1];
                result[0] = new DianResponse
                {
                    StatusCode = "500",
                    StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return result;
            }
            catch (EndpointNotFoundException ex)
            {
                DianResponse[] result = new DianResponse[1];
                result[0] = new DianResponse
                {
                    StatusCode = "500",
                    StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return result;
            }
            catch (CommunicationException ex)
            {
                DianResponse[] result = new DianResponse[1];
                result[0] = new DianResponse
                {
                    StatusCode = "500",
                    StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return result;
            }
            catch (Exception ex)
            {
                DianResponse[] result = new DianResponse[1];
                result[0] = new DianResponse
                {
                    StatusCode = "500",
                    StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return result;
            }
            finally
            {
                stopwatch.Stop();
                //log
            }
        }
    }
}
