using APIComunicationDIAN.Domain.Enum;
using ServiceDIAN;

namespace APIComunicationDIAN.Infraestructure.Interface
{
    public interface ISendTestSetAsync
    {
        Task<UploadDocumentResponse> Send(string namefile, byte[] contentFile, string testSetId, EnvironmentEnum environment);
    }
}
