using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;
using DocumentoEquivalente.Modelo.Supplier;

namespace APIGenerateUBL.Domain.DocumentFill.Extensions
{
    public static class DianExtensionFill
    {

        public static DianExtensions? Set(FacturaGeneral doc, Emisor emisor, IConfiguration _configuration)
        {
            DianExtensions dianExtension = new DianExtensions();

            dianExtension.SoftwareID = _configuration["Credential:SoftwareID"];
            dianExtension.SoftwareSecurityCode = "SoftwareSecurityCode";
            dianExtension.SoftwarePin = _configuration["Credential:SoftwarePin"];

            //Rango de Numeracion
            if (emisor != null)
            {
                if (emisor.RangoNumeracion != null)
                {
                    dianExtension.InvoiceAuthorization = emisor.RangoNumeracion.InvoiceAuthorization;
                    dianExtension.Prefix = emisor.RangoNumeracion.Prefix;
                    dianExtension.From = emisor.RangoNumeracion.RangeFrom.ToString();
                    dianExtension.To = emisor.RangoNumeracion.RangeTo.ToString();
                    dianExtension.StartDate = emisor.RangoNumeracion.StartDate;
                    dianExtension.EndDate = emisor.RangoNumeracion.EndDate;
                    dianExtension.KeyTechnical = emisor.RangoNumeracion.KeyTechnique;
                }
            }
            //Datos de la DIAN valores Estaticos
            dianExtension.AuthorizationProviderID = "800197268";
            dianExtension.AuthorizationProviderIDSchemeAgencyID = DocumentBuildCO.Common.Catalog.DIAN_ID;
            dianExtension.AuthorizationProviderIDSchemeAgencyName = DocumentBuildCO.Common.Catalog.DIAN_AgencyName;
            dianExtension.AuthorizationProviderIDSchemeID = "4";
            dianExtension.AuthorizationProviderIDSchemeName = "31";

            //Estandar
            dianExtension.InvoiceSourceIdentificationCode = "CO";
            dianExtension.InvoiceSourceListAgencyID = "6";
            dianExtension.InvoiceSourceListAgencyName = "United Nations Economic Commission for Europe";
            dianExtension.InvoiceSourceListSchemeURI = "urn:oasis:names:specification:ubl:codelist:gc:CountryIdentificationCode-2.1";

            //Proveedor Tecnologico
            dianExtension.ProviderID = "900390126";
            dianExtension.ProviderID_SchemeID = "6";
            dianExtension.ProviderID_SchemeName = "31";

            dianExtension.QRCode = "UUIDaReemplazar";

            return dianExtension;
        }
    }
}
