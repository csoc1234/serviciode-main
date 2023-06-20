using APIGenerateUBL.Domain.Entity;
using APIGenerateUBL.Domain.Interface;
using APIGenerateUBL.Transversal.Model;
using DocumentoEquivalente.Modelo.Document;
using DocumentoEquivalente.Modelo.Supplier;

namespace APIGenerateUBL.Domain.Core
{
    public class CreateDomain : ICreateDomain
    {
        private readonly IBuildXml _buildXml;
        public CreateDomain(IBuildXml buildXml)
        {
            _buildXml = buildXml;
        }

        public XmlFile Generate(FacturaGeneral facturaGeneral, Emisor emisor)
        {
            try
            {
                //Se consume un metodo para generar el Xml
                XmlFile xmlResult = _buildXml.Generate(facturaGeneral, emisor);

                if (xmlResult.Code == 200)
                {
                    //Se valida el metodo para generar el Xsd
                    ResponseBase xsdResult = _buildXml.ValidaXSD(xmlResult.Xml);

                    if (xsdResult.Code == 200)
                    {
                        return new XmlFile { Code = xsdResult.Code, Message = "Se genero un archivo xml valido", Xml = xmlResult.Xml };
                    }
                    else
                    {
                        return new XmlFile
                        {
                            Code = xsdResult.Code,
                            Message = xsdResult.Message
                        };
                    }
                }
                else
                {
                    return xmlResult;
                }
            }
            catch (Exception ex)
            {
                return new XmlFile { Code = 500, Message = ex.Message, Xml = null };
            }

        }
    }
}
