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
    public class SendBillSync : ISendBillSync
    {
        private readonly IDianClient _dianClient;
        private InspectorBehavior _inspector;
        private IWcfDianCustomerServices _connectionHab;
        private IWcfDianCustomerServices _connectionProd;

        public SendBillSync(IDianClient dianClient)
        {
            _dianClient = dianClient;
            _connectionHab = _dianClient.Connection(EnvironmentEnum.Habilitation);
            _connectionProd = _dianClient.Connection(EnvironmentEnum.Production);
        }

        public async Task<DianResponse> Send(string namefile, byte[] contentFile, EnvironmentEnum environment)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            try
            {
                DianResponse result = new() { };

                //_inspector = new InspectorBehavior();
                //connection.Endpoint.EndpointBehaviors.Add(_inspector);
                if (environment == EnvironmentEnum.Production)
                {
                    result = await _connectionProd.SendBillSyncAsync(namefile, contentFile);
                }
                else
                {
                    result = await _connectionHab.SendBillSyncAsync(namefile, contentFile);
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
                return new DianResponse { StatusCode = "500", StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message };
            }
            catch (WebException ex)
            {
                return new DianResponse { StatusCode = "500", StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message };
            }
            catch (EndpointNotFoundException ex)
            {
                return new DianResponse { StatusCode = "500", StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message };
            }
            catch (CommunicationException ex)
            {
                return new DianResponse { StatusCode = "500", StatusMessage = "Error al momento de procesar la transaccion. " + ex.Message };
            }
            catch (Exception ex)
            {
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
