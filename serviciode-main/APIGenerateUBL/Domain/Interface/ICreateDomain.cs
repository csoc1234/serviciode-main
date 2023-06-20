using APIGenerateUBL.Domain.Entity;
using DocumentoEquivalente.Modelo.Document;
using DocumentoEquivalente.Modelo.Supplier;

namespace APIGenerateUBL.Domain.Interface
{
    public interface ICreateDomain
    {
        XmlFile Generate(FacturaGeneral facturaGeneral, Emisor emisor);
    }
}
