using APIComunicationDIAN.Domain.Enum;
using APIComunicationDIAN.Domain.Helper;
using APIComunicationDIAN.Infraestructure.DianConnection;
using APIComunicationDIAN.Infraestructure.Interface;
using Newtonsoft.Json;
using ServiceDIAN;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.ServiceModel;

namespace APIComunicationDIAN.Infraestructure.ClientSoap
{
    public class GetStatus : IGetStatus
    {
        private readonly IDianClient _dianClient;
        private InspectorBehavior _inspector;
        private IWcfDianCustomerServices _connectionHab;
        private IWcfDianCustomerServices _connectionProd;

        public GetStatus(IDianClient dianClient)
        {
            _dianClient = dianClient;
            _connectionHab = _dianClient.Connection(EnvironmentEnum.Habilitation);
            _connectionProd = _dianClient.Connection(EnvironmentEnum.Production);
        }

        public async Task<DianResponse> Get(string cufe, EnvironmentEnum environment)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string nameMethod = MethodBase.GetCurrentMethod().Name;

            try
            {
                DianResponse result = new() { };

                //_inspector = new InspectorBehavior();
                //connection.Endpoint.EndpointBehaviors.Add(_inspector);
                if (environment == EnvironmentEnum.Production)
                {
                    result = await _connectionProd.GetStatusAsync(cufe);
                }
                else
                {
                    result = await _connectionHab.GetStatusAsync(cufe);
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
                return new DianResponse { StatusCode = "500", StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message };
            }
            catch (TimeoutException ex)
            {
                stopwatch.Stop();
                return new DianResponse { StatusCode = "500", StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message };
            }
            catch (WebException ex)
            {
                stopwatch.Stop();
                return new DianResponse { StatusCode = "500", StatusMessage = nameMethod + ex.GetType().Name + ex.Message + JsonConvert.SerializeObject(ex.InnerException) };
            }
            catch (EndpointNotFoundException ex)
            {
                stopwatch.Stop();
                return new DianResponse { StatusCode = "500", StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message };
            }
            catch (CommunicationException ex)
            {
                stopwatch.Stop();
                return new DianResponse { StatusCode = "500", StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message };
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                return new DianResponse { StatusCode = "500", StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message };
            }
            finally
            {
                stopwatch.Stop();
                //log
            }
        }
    }
}
