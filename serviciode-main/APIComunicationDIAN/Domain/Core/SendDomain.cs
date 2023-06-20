using APIComunicationDIAN.Common;
using APIComunicationDIAN.Domain.Enum;
using APIComunicationDIAN.Domain.Interface;
using APIComunicationDIAN.Infraestructure.Interface;
using ServiceDIAN;

namespace APIComunicationDIAN.Domain.Core
{
    public class SendDomain : ISendDomain
    {
        private readonly ISendTestSetAsync _sendTestSetAsync;
        private readonly ISendBillSync _sendBillSync;

        public SendDomain(ISendTestSetAsync sendTestSetAsync, ISendBillSync sendBillSync)
        {
            _sendTestSetAsync = sendTestSetAsync;
            _sendBillSync = sendBillSync;
        }

        public async Task<UploadDocumentResponse> SendAsync(string namefile, string xmlFile, string testSetId, EnvironmentEnum environment)
        {
            try
            {
                //Transformacion de document a .zip
                byte[] contentFile = XmlToZip.Convert(xmlFile, namefile);

                if (contentFile.Length > 0)
                {
                    //Consumo de Infraestructure
                    UploadDocumentResponse result = await _sendTestSetAsync.Send(namefile, contentFile, testSetId, environment);

                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        XmlParamsResponseTrackId[] ErrorMessageList = new XmlParamsResponseTrackId[1];
                        ErrorMessageList[0] = new XmlParamsResponseTrackId
                        {
                            SenderCode = "500",
                            Success = false,
                            ProcessedMessage = "No se recibio respuesta por parte de la DIAN"
                        };

                        return new UploadDocumentResponse
                        {
                            ErrorMessageList = ErrorMessageList
                        };
                    }
                }
                else
                {
                    XmlParamsResponseTrackId[] ErrorMessageList = new XmlParamsResponseTrackId[1];
                    ErrorMessageList[0] = new XmlParamsResponseTrackId
                    {
                        SenderCode = "500",
                        Success = false,
                        ProcessedMessage = "Error al momento de comprimir"
                    };

                    return new UploadDocumentResponse
                    {
                        ErrorMessageList = ErrorMessageList
                    };
                }
            }
            catch (Exception ex)
            {
                XmlParamsResponseTrackId[] ErrorMessageList = new XmlParamsResponseTrackId[1];
                ErrorMessageList[0] = new XmlParamsResponseTrackId
                {
                    SenderCode = "500",
                    Success = false,
                    ProcessedMessage = ex.Message
                };

                return new UploadDocumentResponse
                {
                    ErrorMessageList = ErrorMessageList
                };
            }
        }

        public async Task<DianResponse> SendBill(string namefile, string xmlFile, EnvironmentEnum environment)
        {
            try
            {
                //Transformacion de document a .zip
                byte[] contentFile = XmlToZip.Convert(xmlFile, namefile);

                if (contentFile.Length > 0)
                {
                    //Consumo de Infraestructure
                    DianResponse result = await _sendBillSync.Send(namefile, contentFile, environment);

                    if (result != null)
                    {
                        return result;
                    }
                    else
                    {
                        return new DianResponse
                        {
                            StatusCode = "500",
                            StatusMessage = "No se recibio respuesta por parte de la DIAN"
                        };
                    }
                }
                else
                {
                    return new DianResponse
                    {
                        StatusCode = "500",
                        StatusMessage = "Error al momento de comprimir"
                    };
                }
            }
            catch (Exception ex)
            {
                return new DianResponse
                {
                    StatusCode = "500",
                    StatusMessage = ex.Message
                };
            }
        }
    }
}
