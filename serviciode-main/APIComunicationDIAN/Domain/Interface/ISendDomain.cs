using APIComunicationDIAN.Domain.Enum;
using ServiceDIAN;

namespace APIComunicationDIAN.Domain.Interface
{
    public interface ISendDomain
    {
        Task<DianResponse> SendBill(string namefile, string xmlFile, EnvironmentEnum environment);

        Task<UploadDocumentResponse> SendAsync(string namefile, string xmlFile, string testSetId, EnvironmentEnum environment);
    }
}
