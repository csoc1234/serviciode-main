using DocumentoEquivalente.Modelo.Document;
using DocumentoEquivalente.Modelo.Supplier;

namespace APIGenerateUBL.Application.Dto
{
    public class DocumentDtoRequest
    {
        public FacturaGeneral FacturaGeneral { get; set; }
        public Emisor Emisor { get; set; }
    }
}
