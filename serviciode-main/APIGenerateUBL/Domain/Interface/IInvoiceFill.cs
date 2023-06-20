using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;
using DocumentoEquivalente.Modelo.Supplier;

namespace APIGenerateUBL.Domain.Interface
{
    public interface IInvoiceFill
    {
        BaseDocument21 Set(FacturaGeneral request, Emisor emisor);
    }
}
