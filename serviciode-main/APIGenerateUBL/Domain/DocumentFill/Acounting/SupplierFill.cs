using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Supplier;

namespace APIGenerateUBL.Domain.DocumentFill.Acounting
{
    public static class SupplierFill
    {
        public static AcountingSupplierParty Set(Emisor emisor)
        {
            AcountingSupplierParty doc21 = new AcountingSupplierParty();

            doc21.AdditionalAccountID = Int32.TryParse(emisor.AccountId, out int AdditionalAccountID) ? AdditionalAccountID : 1;
            doc21.AdditionalAccountID_SchemeAgencyID = emisor.SchemeAgencyId;
            doc21.AdditionalAccountID_SchemeID = emisor.VerificationDigit;
            doc21.AdditionalAccountID_SchemeName = emisor.DocumentType;

            doc21.LegalEntity = new PartyLegalEntity();
            doc21.LegalEntity.CompanyID = emisor.LegalCompanyId;
            doc21.LegalEntity.CompanySchemeID = emisor.LegalVerificationDigit;
            doc21.LegalEntity.CompanySchemeName = emisor.LegalDocumentType;
            doc21.LegalEntity.CompanySchemeAgencyID = DocumentBuildCO.Common.Catalog.DIAN_ID;
            doc21.LegalEntity.CompanySchemeAgencyName = DocumentBuildCO.Common.Catalog.DIAN_AgencyName;
            doc21.LegalEntity.CorporateRegistrationID = emisor.RangoNumeracion.Prefix;
            doc21.LegalEntity.RegistrationName = emisor.RegistrationName;

            doc21.PartyName = emisor.PartyName;

            //Contact
            if (emisor.Contact != null)
            {
                doc21.ASContact = new AcountingSupplierPartyContact();
                doc21.ASContact.ElectronicMail = emisor.Contact.Email;
                doc21.ASContact.Telephone = emisor.Contact.Telephone;
                doc21.ASContact.Telefax = emisor.Contact.Telefax;
                doc21.ASContact.Note = emisor.Contact.Note;
                doc21.ASContact.Name = emisor.Contact.NamePerson;
            }

            if (emisor.AddressSucursal != null)
            {
                doc21.PhysicalLocation = AddressFill.Set(emisor.AddressSucursal);
            }

            doc21.TaxScheme = new PartyTaxScheme();


            doc21.TaxScheme.TaxSchemeID = "";
            doc21.TaxScheme.TaxSchemeName = "";

            if ((emisor.Tributarias != null) && !string.IsNullOrEmpty(emisor.Tributarias.FirstOrDefault()))
            {
                doc21.TaxScheme.TaxSchemeID = emisor.Tributarias.FirstOrDefault();
            }
            /*
            if (emisor.enterprise.environment == (int)DianConnection.Ambientes.PRODUCCION)
            {
                if (Diccionarios.Aplicacion[Parametros.CatalogoPropioDetallesTributariosProdActivo] == "1")
                {
                    if (!UtilitiesString.DiccionarioTipoDetalleTributario.ContainsKey(doc21.AcountingSupplierParty.TaxScheme.TaxSchemeID))
                    {
                        doc21.AcountingSupplierParty.TaxScheme.TaxSchemeID = Diccionarios.Aplicacion[Parametros.ValorPorDefectoDetallesTributariosProd];
                    }
                    doc21.AcountingSupplierParty.TaxScheme.TaxSchemeName = UtilitiesString.DiccionarioTipoDetalleTributario[doc21.AcountingSupplierParty.TaxScheme.TaxSchemeID];
                }
            }
            else
            {
                if (Diccionarios.Aplicacion[Parametros.CatalogoPropioDetallesTributariosHabActivo] == "1")
                {
                    if (!UtilitiesString.DiccionarioTipoDetalleTributario.ContainsKey(doc21.AcountingSupplierParty.TaxScheme.TaxSchemeID))
                    {
                        doc21.AcountingSupplierParty.TaxScheme.TaxSchemeID = Diccionarios.Aplicacion[Parametros.ValorPorDefectoDetallesTributariosHab];
                    }
                    doc21.AcountingSupplierParty.TaxScheme.TaxSchemeName = UtilitiesString.DiccionarioTipoDetalleTributario[doc21.AcountingSupplierParty.TaxScheme.TaxSchemeID];
                }
            }
            if (string.IsNullOrEmpty(doc21.TaxScheme.TaxSchemeName))
            {
                if (UtilitiesString.DiccionarioTipoDeImpuesto.ContainsKey(emisor.enterprise.tributarias.FirstOrDefault().code))
                {
                    doc21.AcountingSupplierParty.TaxScheme.TaxSchemeName = UtilitiesString.DiccionarioTipoDeImpuesto[emisor.enterprise.tributarias.FirstOrDefault().code];
                }
            }*/


            doc21.TaxScheme.RegistrationName = emisor.RegistrationName;

            doc21.TaxScheme.TaxLevelCodeListName = !String.IsNullOrWhiteSpace(emisor.TaxLevelCode) ? emisor.TaxLevelCode : "04";

            if (emisor.Responsabilidades != null)
            {
                int i = 0;
                foreach (string? row in emisor.Responsabilidades)
                {
                    if (i >= 1)
                        doc21.TaxScheme.TaxLevelCode += ";";
                    doc21.TaxScheme.TaxLevelCode += row;
                    i++;
                }
            }

            doc21.TaxScheme.CompanyID = emisor.CompanyId;
            doc21.TaxScheme.SchemeID = emisor.VerificationDigit;
            doc21.TaxScheme.SchemeName = emisor.DocumentType;
            doc21.TaxScheme.SchemeAgencyID = DocumentBuildCO.Common.Catalog.DIAN_ID;
            doc21.TaxScheme.SchemeAgencyName = DocumentBuildCO.Common.Catalog.DIAN_AgencyName;

            if (emisor.AddressesRut != null)
            {
                doc21.TaxScheme.RegistrationAddress = AddressFill.Set(emisor.AddressesRut);
            }

            if (emisor.CiiuCodes != null)
            {
                int j = 0;
                foreach (string code in emisor.CiiuCodes)
                {
                    if (j >= 1)
                        doc21.IndustryClassificationCode += ";";
                    doc21.IndustryClassificationCode += code;
                    j++;
                }
            }

            return doc21;
        }
    }
}
