using APIGenerateUBL.Domain.Entity;
using APIGenerateUBL.Domain.Interface;
using APIGenerateUBL.Transversal.Model;
using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO;
using DocumentBuildCO.Common;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentBuildCO.Response;
using DocumentBuildCO.Validate;
using DocumentoEquivalente.Modelo.Document;
using DocumentoEquivalente.Modelo.Supplier;
using System.Reflection;

namespace APIGenerateUBL.Domain.Core
{
    public class BuildXml : IBuildXml
    {
        private readonly IConfiguration _configuration;

        private readonly IInvoiceFill _invoiceFill;

        public BuildXml(IConfiguration configuration, IInvoiceFill invoiceFill)
        {
            _configuration = configuration;
            _invoiceFill = invoiceFill;
        }

        public XmlFile Generate(FacturaGeneral facturaGeneral, Emisor emisor)
        {
            BaseDocument21? doc = _invoiceFill.Set(facturaGeneral, emisor);

            int decimalQuantity = 0;

            int.TryParse(facturaGeneral.CantidadDecimales, out decimalQuantity);

            BuildResponse? resultXml = Build21.Document(doc, ref decimalQuantity);

            if (!string.IsNullOrEmpty(resultXml.xml))
            {
                return new XmlFile
                {
                    Code = 200,
                    Message = "Exitoso",
                    Xml = resultXml.xml
                };
            }
            else
            {
                return new XmlFile
                {
                    Code = 500,
                    Message = "Error al generar el xml",
                    Xml = null
                };
            }
        }

        public ResponseBase ValidaXSD(string xml)
        {
            try
            {
                //Request
                TypeDocument documentType = TypeDocument.Invoice;
                string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar;
                UBL_Version ublVersion = UBL_Version.UBL2_1;
                xml = UtilitiesString.Base64Decode(xml);

                //Consuming Method
                XSDResponse result = ValidateDocument.validatewithXSD(documentType, xml, path, ublVersion);

                if (result.code == 0)
                {
                    return new ResponseBase { Code = 200, Message = "Exitoso" };
                }
                else
                {
                    return new ResponseBase { Code = result.code, Message = "El xml no cumple con la estructura UBL 2.1" + result.message };
                }
            }
            catch (Exception ex)
            {
                return new ResponseBase { Code = 500, Message = ex.Message };
            }
        }
    }
}
