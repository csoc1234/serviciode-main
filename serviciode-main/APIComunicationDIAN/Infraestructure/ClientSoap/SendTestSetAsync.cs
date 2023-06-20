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
    public class SendTestSetAsync : ISendTestSetAsync
    {
        private readonly IDianClient _dianClient;
        private InspectorBehavior _inspector;
        private IWcfDianCustomerServices _connectionHab;
        private IWcfDianCustomerServices _connectionProd;

        public SendTestSetAsync(IDianClient dianClient)
        {
            _dianClient = dianClient;
            _connectionHab = _dianClient.Connection(EnvironmentEnum.Habilitation);
            _connectionProd = _dianClient.Connection(EnvironmentEnum.Production);
        }

        public async Task<UploadDocumentResponse> Send(string namefile, byte[] contentFile, string testSetId, EnvironmentEnum environment)
        {
            Stopwatch stopwatch = new();
            stopwatch.Start();

            try
            {
                UploadDocumentResponse result = new() { };

                //_inspector = new InspectorBehavior();
                //connection.Endpoint.EndpointBehaviors.Add(_inspector);
                if (environment == EnvironmentEnum.Production)
                {
                    result = await _connectionProd.SendTestSetAsyncAsync(namefile, contentFile, testSetId);
                }
                else
                {
                    result = await _connectionHab.SendTestSetAsyncAsync(namefile, contentFile, testSetId);
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

                XmlParamsResponseTrackId[] ErrorMessageList = new XmlParamsResponseTrackId[1];
                ErrorMessageList[0] = new XmlParamsResponseTrackId
                {
                    SenderCode = "500",
                    Success = false,
                    ProcessedMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return new UploadDocumentResponse
                {
                    ErrorMessageList = ErrorMessageList
                };
            }
            catch (TimeoutException ex)
            {
                XmlParamsResponseTrackId[] ErrorMessageList = new XmlParamsResponseTrackId[1];
                ErrorMessageList[0] = new XmlParamsResponseTrackId
                {
                    SenderCode = "500",
                    Success = false,
                    ProcessedMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return new UploadDocumentResponse
                {
                    ErrorMessageList = ErrorMessageList
                };
            }
            catch (WebException ex)
            {
                XmlParamsResponseTrackId[] ErrorMessageList = new XmlParamsResponseTrackId[1];
                ErrorMessageList[0] = new XmlParamsResponseTrackId
                {
                    SenderCode = "500",
                    Success = false,
                    ProcessedMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return new UploadDocumentResponse
                {
                    ErrorMessageList = ErrorMessageList
                };
            }
            catch (EndpointNotFoundException ex)
            {
                XmlParamsResponseTrackId[] ErrorMessageList = new XmlParamsResponseTrackId[1];
                ErrorMessageList[0] = new XmlParamsResponseTrackId
                {
                    SenderCode = "500",
                    Success = false,
                    ProcessedMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return new UploadDocumentResponse
                {
                    ErrorMessageList = ErrorMessageList
                };
            }
            catch (CommunicationException ex)
            {
                XmlParamsResponseTrackId[] ErrorMessageList = new XmlParamsResponseTrackId[1];
                ErrorMessageList[0] = new XmlParamsResponseTrackId
                {
                    SenderCode = "500",
                    Success = false,
                    ProcessedMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return new UploadDocumentResponse
                {
                    ErrorMessageList = ErrorMessageList
                };
            }
            catch (Exception ex)
            {
                XmlParamsResponseTrackId[] ErrorMessageList = new XmlParamsResponseTrackId[1];
                ErrorMessageList[0] = new XmlParamsResponseTrackId
                {
                    SenderCode = "500",
                    Success = false,
                    ProcessedMessage = "Error al momento de procesar la transaccion. " + ex.Message
                };

                return new UploadDocumentResponse
                {
                    ErrorMessageList = ErrorMessageList
                };
            }
            finally
            {
                stopwatch.Stop();
                //log
            }
        }
    }
}
