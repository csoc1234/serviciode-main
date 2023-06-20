using APIGenerateUBL.Domain.Entity;
using APIGenerateUBL.Transversal.Model;
using DocumentoEquivalente.Modelo.Document;
using DocumentoEquivalente.Modelo.Supplier;

namespace APIGenerateUBL.Domain.Interface
{
    public interface IBuildXml
    {
        XmlFile Generate(FacturaGeneral facturaGeneral, Emisor emisor);

        ResponseBase ValidaXSD(string xml);
    }
}
