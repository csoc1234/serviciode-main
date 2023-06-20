using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;

namespace APIGenerateUBL.Domain.DocumentFill.Acounting
{
    public static class CustomerFill
    {
        public static AccountingCustomerParty Set(FacturaGeneral doc)
        {
            AccountingCustomerParty doc21 = new AccountingCustomerParty();


            doc21.AdditionalAccountID = Int32.TryParse(doc.Cliente.tipoPersona.Trim().ToString(), out int tipoPersona) ? tipoPersona : 1;

            if (doc.Cliente.tipoPersona == "2")
            {
                doc21.PartyIdentificationID = doc.Cliente.numeroDocumento.Trim();
                doc21.PartyIdentificationID_SchemeName = doc.Cliente.tipoIdentificacion.Trim();
                doc21.PartyIdentificationID_SchemeID = doc.Cliente.numeroIdentificacionDV.Trim();
            }

            if (doc.Cliente.informacionLegalCliente != null)
            {
                doc21.LegalEntity = new PartyLegalEntity();
                //doc21.LegalEntity.CompanySchemeName = doc.Cliente.informacionLegalCliente.tipoIdentificacion.Trim();
                //doc21.LegalEntity.CompanyID = doc.Cliente.informacionLegalCliente.numeroIdentificacion.Trim();
                //doc21.LegalEntity.CompanySchemeAgencyName = DocumentBuildCO.Common.Catalog.DIAN_AgencyName;
                //doc21.LegalEntity.CompanySchemeAgencyID = DocumentBuildCO.Common.Catalog.DIAN_ID;
                //doc21.LegalEntity.CompanySchemeID = doc.Cliente.informacionLegalCliente.numeroIdentificacionDV.Trim();

                //doc21.LegalEntity.RegistrationName = doc.Cliente.informacionLegalCliente.nombreRegistroRUT.Trim();

                //doc21.LegalEntity.CorporateRegistrationID = doc.Cliente.informacionLegalCliente.prefijoFacturacion;
                //doc21.LegalEntity.CorporateRegistrationName = doc.Cliente.informacionLegalCliente.numeroMatriculaMercantil;
                //doc21.LegalEntity.CorporateRegistrationTypeCode = doc.Cliente.informacionLegalCliente.codigoEstablecimiento;
            }

            doc21.PartyName = doc.Cliente.nombreComercial.Trim();

            if (doc.Cliente.direccionCliente != null)
            {
                doc21.PhysicalLocation = AddressFill.Set(doc.Cliente.direccionCliente);
            }


            doc21.ACContact = new AccountingCustomerPartyContact();
            doc21.ACContact.ContactElectronicMail = doc.Cliente.email.Trim();
            doc21.ACContact.ContactName = doc.Cliente.nombreContacto.Trim();
            doc21.ACContact.ContactNote = doc.Cliente.nota.Trim();
            doc21.ACContact.ContactTelefax = doc.Cliente.telefax.Trim();
            doc21.ACContact.ContactTelephone = doc.Cliente.telefono.Trim();

            doc21.TaxScheme = new PartyTaxScheme();

            if (doc.Cliente.detallesTributarios != null)
            {

                if (doc.Cliente.detallesTributarios.Count > 0)
                {
                    if (doc.Cliente.detallesTributarios.First() != null)
                    {
                        doc21.TaxScheme.TaxSchemeID = "";
                        doc21.TaxScheme.TaxSchemeName = "";
                        Tributos? detallesTributarios = doc.Cliente.detallesTributarios.First();
                        if ((detallesTributarios != null) && !string.IsNullOrEmpty(detallesTributarios.CodigoImpuesto))
                        {
                            doc21.TaxScheme.TaxSchemeID = detallesTributarios.CodigoImpuesto.Trim();
                        }

                        /*if (emisor.enterprise.environment == (int)DianConnection.Ambientes.PRODUCCION)
                        {
                            if (Diccionarios.Aplicacion[Parametros.CatalogoPropioDetallesTributariosProdActivo] == "1")
                            {
                                if (!UtilitiesString.DiccionarioTipoDetalleTributario.ContainsKey(doc21.AccountingCustomerParty.TaxScheme.TaxSchemeID))
                                {
                                    doc21.AccountingCustomerParty.TaxScheme.TaxSchemeID = Diccionarios.Aplicacion[Parametros.ValorPorDefectoDetallesTributariosProd];
                                }
                                doc21.AccountingCustomerParty.TaxScheme.TaxSchemeName = UtilitiesString.DiccionarioTipoDetalleTributario[doc21.AccountingCustomerParty.TaxScheme.TaxSchemeID];
                            }
                        }
                        else
                        {
                            if (Diccionarios.Aplicacion[Parametros.CatalogoPropioDetallesTributariosHabActivo] == "1")
                            {
                                if (!UtilitiesString.DiccionarioTipoDetalleTributario.ContainsKey(doc21.AccountingCustomerParty.TaxScheme.TaxSchemeID))
                                {
                                    doc21.AccountingCustomerParty.TaxScheme.TaxSchemeID = Diccionarios.Aplicacion[Parametros.ValorPorDefectoDetallesTributariosHab];
                                }
                                doc21.AccountingCustomerParty.TaxScheme.TaxSchemeName = UtilitiesString.DiccionarioTipoDetalleTributario[doc21.AccountingCustomerParty.TaxScheme.TaxSchemeID];
                            }
                        }
                        if (string.IsNullOrEmpty(doc21.AccountingCustomerParty.TaxScheme.TaxSchemeName))
                        {
                            if (UtilitiesString.DiccionarioTipoDeImpuesto.ContainsKey(doc21.AccountingCustomerParty.TaxScheme.TaxSchemeID))
                            {
                                doc21.AccountingCustomerParty.TaxScheme.TaxSchemeName = UtilitiesString.DiccionarioTipoDeImpuesto[doc21.AccountingCustomerParty.TaxScheme.TaxSchemeID];
                            }
                        }*/
                    }
                }

            }

            if (doc.Cliente.direccionFiscal != null)
            {
                doc21.TaxScheme.RegistrationAddress = AddressFill.Set(doc.Cliente.direccionFiscal);
            }

            doc21.TaxScheme.RegistrationName = doc.Cliente.nombreRazonSocial.Trim();

            doc21.IndustryClassificationCode = doc.Cliente.actividadEconomicaCIIU;

            doc21.TaxScheme.SchemeName = doc.Cliente.tipoIdentificacion.Trim();
            doc21.TaxScheme.CompanyID = doc.Cliente.numeroDocumento.Trim();
            doc21.TaxScheme.SchemeAgencyName = DocumentBuildCO.Common.Catalog.DIAN_AgencyName;
            doc21.TaxScheme.SchemeAgencyID = DocumentBuildCO.Common.Catalog.DIAN_ID;
            doc21.TaxScheme.SchemeID = doc.Cliente.numeroIdentificacionDV.Trim();

            if (doc.Cliente.responsabilidadesRut != null)
            {
                if (doc.Cliente.responsabilidadesRut.Count > 0)
                {
                    IEnumerable<Obligaciones>? responsabilidadesRut = doc.Cliente.responsabilidadesRut.Where(o => o.Regimen == doc.Cliente.responsabilidadesRut.First().Regimen);
                    List<string> obligation_list = responsabilidadesRut.Select(ol => ol.obligaciones).Distinct().ToList();
                    doc21.TaxScheme.TaxLevelCode = String.Join(";", obligation_list) ?? String.Empty;

                    doc21.TaxScheme.TaxLevelCodeListName = responsabilidadesRut.First().Regimen.Trim() ?? String.Empty;

                    /* if (emisor.enterprise.environment == (int)DianConnection.Ambientes.PRODUCCION)
                     {
                         if (Diccionarios.Aplicacion[Parametros.RegimenAdquirienteProdActivo] == "1")
                         {
                             doc21.TaxScheme.TaxLevelCodeListName = Diccionarios.Aplicacion[Parametros.ValorPorDefectoRegimenAdquirienteProd];
                         }
                     }
                     else
                     {
                         if (Diccionarios.Aplicacion[Parametros.RegimenAdquirienteHabActivo] == "1")
                         {
                             doc21.TaxScheme.TaxLevelCodeListName = Diccionarios.Aplicacion[Parametros.ValorPorDefectoRegimenAdquirienteHab];
                         }
                     }*/
                }
            }


            return doc21;
        }
    }
}
