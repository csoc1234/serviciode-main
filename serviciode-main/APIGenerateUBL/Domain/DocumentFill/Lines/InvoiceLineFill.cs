using APIGenerateUBL.Domain.DocumentFill.Totals;
using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;
using DocumentoEquivalente.Modelo.Supplier;

namespace APIGenerateUBL.Domain.DocumentFill.Lines
{
    public static class InvoiceLineFill
    {

        public static List<InvoiceLine> Set(FacturaGeneral doc, Emisor emisor)
        {
            if (doc.DetalleDeFactura != null)
            {
                List<InvoiceLine>? invoiceLine = new List<InvoiceLine>();

                int count = 1;

                foreach (FacturaDetalle linea in doc.DetalleDeFactura)
                {
                    if (linea != null)
                    {
                        InvoiceLine line = new InvoiceLine();

                        line.ID = int.TryParse(linea.Secuencia.Trim(), out int id) ? id : 0;
                        line.ID_schemeID = linea.IdEsquema;

                        //line.ID_schemeID = LinesSchemeID.schemeIdLogic(doc.tipoOperacion, emisor.enterprise.environment, linea.idEsquema, doc.EsDocumentoMandato(), linea.EsIngresoTercerosMandato());

                        line.DescripcionItem = linea.Descripcion.Trim();
                        /* if (doc.tipoDocumento == Constantes.TipoDocumento.FacturaDocumentoSoporte || doc.tipoDocumento == Constantes.TipoDocumento.NotaAjusteDocumentoSoporte)
                         {
                             if (!string.IsNullOrEmpty(linea.descripcion2) && !string.IsNullOrEmpty(linea.descripcion3))
                             {
                                 InvoicePeriod invoicePeriod = LoadInvoicePeriod(linea);
                                 line.InvoicePeriod = new List<InvoicePeriod>();
                                 if (invoicePeriod != null)
                                 {
                                     line.InvoicePeriod.Add(invoicePeriod);
                                 }
                             }

                         }
                         else
                         {
                             line.DescripcionItem2 = linea.descripcion2.Trim();
                             line.DescripcionItem3 = linea.descripcion3.Trim();
                         }

                         if (doc.EsEscenarioSectorSalud("1"))
                         {
                             line.DescripcionItem = Models.Documents.GeneralSalud.GetDescripcionGeneral(linea.descripcion.Trim());
                             if (Diccionarios.Aplicacion[Parametros.SectorSaludInvoiceLineUUIDActive] == "1")
                             {
                                 line.UUID = doc.sectorSalud.Pacientes[0].GetValorCampoGeneral("3");
                             }
                             if (Diccionarios.Aplicacion[Parametros.SectorSaludBuyersItemIdentificationNodeActive] == "1")
                             {
                                 line.BuyersItemIdentificationID = doc.sectorSalud.Pacientes[0].GetValorCampoGeneral("11");
                                 line.BuyersItemIdentificationschemeAgencyID = doc.sectorSalud.Pacientes[0].GetValorCampoGeneral("1");
                                 line.BuyersItemIdentificationschemeName = "AutorizaID-ERP/EPS";
                             }
                         }

                         if (doc.EsEscenarioSectorSalud("2"))
                         {
                             line.UUID = doc.sectorSalud.Pacientes[0].GetValorCampoGeneral("3");
                             line.BuyersItemIdentificationID = doc.sectorSalud.Pacientes[0].GetValorCampoGeneral("11");
                             line.BuyersItemIdentificationschemeAgencyID = doc.sectorSalud.Pacientes[0].GetValorCampoGeneral("1");
                             line.BuyersItemIdentificationschemeName = "AutorizaID-ERP/EPS";
                         }*/

                        line.SellersItemIdentification_ID = linea.CodigoProducto.Trim();

                        line.Quantity = UtilitiesString.ConvertDecimal(linea.CantidadUnidades);
                        line.Quantity_unitCode = linea.UnidadMedida.Trim();

                        line.BaseQuantity = UtilitiesString.ConvertDecimal(linea.CantidadReal);

                        line.BaseQuantity_unitCode = linea.CantidadRealUnidadMedida.Trim();

                        line.AlternativeConditionPrice = new List<AlternativeConditionPrice>();
                        line.PriceAmount = UtilitiesString.ConvertDecimal(linea.PrecioVentaUnitario);
                        line.PriceAmount_currencyID = doc.Moneda;

                        line.LineExtensionAmount = UtilitiesString.ConvertDecimal(linea.PrecioTotalSinImpuestos);
                        line.LineExtensionAmount_currencyID = doc.Moneda;

                        //Serial                        
                        //bool muestraGratis = linea.muestraGratis.Trim() == "1" ? true : false;
                        //line.FreeOfChargeIndicator = muestraGratis;

                        line.Note = linea.Nota.Trim();
                        line.AlternativeConditionPrice = new List<AlternativeConditionPrice>();

                        if (linea.PrecioReferencia.Trim() != "" && linea.CodigoTipoPrecio.Trim() != "")
                        {
                            AlternativeConditionPrice alternativeConditionPrice = new AlternativeConditionPrice();
                            alternativeConditionPrice.PriceAmount = UtilitiesString.ConvertDecimalNullable(linea.PrecioReferencia);
                            alternativeConditionPrice.PriceAmount_currencyID = doc.Moneda;
                            alternativeConditionPrice.PriceTypeCode = linea.CodigoTipoPrecio.Trim();
                            line.AlternativeConditionPrice.Add(alternativeConditionPrice);
                        }

                        line.PackSizeNumeric = UtilitiesString.ConvertDecimalNullable(linea.CantidadPorEmpaque);
                        //line.AdditionalInformation = linea.descripcionTecnica.Trim();

                        line.BrandName = linea.Marca.Trim();
                        line.ModelName = linea.Modelo.Trim();
                        line.SellersItemIdentification_ExtendedID = linea.SubCodigoProducto.Trim();
                        //line.ManufacturersItemIdentification_ID = linea.codigoFabricante.Trim();
                        line.ManufacturersItemIdentification_ExtendedID = linea.SubCodigoProducto.Trim();
                        //line.PartyNameManufacturers = linea.nombreFabricante.Trim();

                        InvoiceLine? StandardItemIdentification = LoadStandardItemIdentification(linea);
                        if (StandardItemIdentification != null)
                        {
                            line.StandardItemIdentification_ID = StandardItemIdentification.StandardItemIdentification_ID;
                            line.StandardItemIdentification_SchemeID = StandardItemIdentification.StandardItemIdentification_SchemeID;
                            line.StandardItemIdentification_SchemeName = !string.IsNullOrEmpty(StandardItemIdentification.StandardItemIdentification_SchemeName) ? StandardItemIdentification.StandardItemIdentification_SchemeName : null;
                            line.StandardItemIdentification_SchemeAgencyID = StandardItemIdentification.StandardItemIdentification_SchemeAgencyID;
                            line.StandardItemIdentification_SchemeAgencyName = StandardItemIdentification.StandardItemIdentification_SchemeAgencyName;
                            line.StandardItemIdentification_SchemeDataURI = StandardItemIdentification.StandardItemIdentification_SchemeDataURI;
                            line.StandardItemIdentification_ExtendedID = StandardItemIdentification.StandardItemIdentification_ExtendedID;
                            line.StandardItemIdentificationName = StandardItemIdentification.StandardItemIdentificationName;
                        }
                        //line.CountryIdentificationCode = linea.codigoIdentificadorPais.Trim();
                        //line.PowerOfAttorneyAgentPartyID = linea.mandatorioNumeroIdentificacion.Trim();
                        //line.PowerOfAttorneyAgentPartySchemeID = linea.mandatorioNumeroIdentificacionDV.Trim();
                        //line.PowerOfAttorneyAgentPartySchemeName = linea.mandatorioTipoIdentificacion.Trim();

                        line.AdditionalItemProperty = new List<AdditionalItemProperty>();


                        if (linea.InformacionAdicional != null)
                        {
                            foreach (LineaInformacionAdicional extensible in linea.InformacionAdicional)
                            {
                                if (extensible != null)
                                {
                                    //if (String.IsNullOrEmpty(extensible.tipo) || extensible.tipo == "1")
                                    //{
                                    AdditionalItemProperty ce = new AdditionalItemProperty();
                                    //ce.ID = extensible.secuencia;
                                    ce.Name = extensible.nombre.Trim();
                                    //ce.NameCode = extensible.codigo.Trim();
                                    ce.Value = extensible.valor.Trim();
                                    //ce.Description = extensible.descripcion.Trim();
                                    //ce.StartDate = UtilitiesString.ConvertDateTimeNullable(extensible.fechaInicio);
                                    //ce.EndDate = UtilitiesString.ConvertDateTimeNullable(extensible.fechaFin);
                                    ce.ValueQuantity = extensible.cantidad.Trim();
                                    ce.ValueQuantity_unitCode = extensible.unidadMedida.Trim();
                                    /*
                                    ce.ValueQuantity_unitCode = null;

                                    if (doc.tipoOperacion == Diccionarios.Aplicacion[Parametros.TransporteTipoOperacionPorDefecto])
                                    {
                                        if (emisor.enterprise.environment == (int)DianConnection.Ambientes.PRODUCCION)
                                        {
                                            if (Diccionarios.Aplicacion[Parametros.TransporteUnitCodeProdActivo] == "1")
                                            {
                                                if (extensible.nombre == Diccionarios.Aplicacion[Parametros.UnidadMedidaTransporteInfoAdicionalNombre])
                                                {
                                                    ce.ValueQuantity_unitCode = extensible.unidadMedidaTransporte;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Diccionarios.Aplicacion[Parametros.TransporteUnitCodeHabActivo] == "1")
                                            {
                                                if (extensible.nombre == Diccionarios.Aplicacion[Parametros.UnidadMedidaTransporteInfoAdicionalNombre])
                                                {
                                                    ce.ValueQuantity_unitCode = extensible.unidadMedidaTransporte;
                                                }
                                            }
                                        }
                                    }*/

                                    line.AdditionalItemProperty.Add(ce);
                                    //}
                                }
                            }
                        }



                        /* line.DiscrepancyCreditLine = new List<DiscrepancyResponse>();
                         if (linea.documentosReferenciados != null)
                         {

                             foreach (DocumentoReferenciado dref in linea.documentosReferenciados)
                             {
                                 if (dref != null)
                                 {
                                     DiscrepancyResponse discResponse = new DiscrepancyResponse();
                                     discResponse.ReferenceID = dref.numeroDocumento.Trim();
                                     discResponse.UUID = dref.cufeDocReferenciado.Trim();
                                     discResponse.UUIDSchemeName = dref.tipoCUFE.Trim();
                                     discResponse.Description = new List<string>();
                                     discResponse.Description = dref.descripcion;
                                     line.DiscrepancyCreditLine.Add(discResponse);
                                 }
                             }
                         }*/


                        line.AllowanceCharge = AllowanceChargeFill.Set(linea.CargosDescuentos, doc.Moneda);
                        line.TaxTotal = TaxTotalFill.SetTaxTotals(linea.ImpuestosDetalles, linea.ImpuestosTotales, doc.Moneda);
                        line.WithholdingTaxTotal = WithholdingTaxTotalFill.SetTaxTotal(linea.ImpuestosDetalles, linea.ImpuestosTotales, doc.Moneda);

                        /* if (!string.IsNullOrEmpty(linea.seriales))
                         {
                             var listSeriales = linea.seriales.Split(',').ToList();
                             if (listSeriales.Count > 0)
                                 line.ItemInstanceSerialID = listSeriales;
                         }*/

                        invoiceLine.Add(line);

                        count++;
                    }

                }
                if (invoiceLine != null)
                {
                    if (invoiceLine.Count() == 0)
                    {
                        throw new System.Exception("El documento debe tener al menos un producto válido");
                    }

                }
                else
                {
                    throw new System.Exception("El documento debe tener al menos un producto válido");
                }

                return invoiceLine;
            }
            else
            {
                throw new System.Exception("El documento debe tener al menos un producto válido");
            }
        }


        public static InvoiceLine LoadStandardItemIdentification(FacturaDetalle linea)
        {
            InvoiceLine invoiceLine = new InvoiceLine();
            if (!string.IsNullOrEmpty(linea.EstandarCodigoProducto.Trim()))
            {
                invoiceLine.StandardItemIdentification_ID = linea.EstandarCodigoProducto.Trim();
                invoiceLine.StandardItemIdentification_SchemeID = linea.EstandarCodigo.Trim();

                //if (Diccionarios.DocumentoSoporte.CodigoEstandarProducto.ContainsKey(linea.EstandarCodigo.Trim()))
                //{
                //invoiceLine.StandardItemIdentification_SchemeName = Diccionarios.DocumentoSoporte.CodigoEstandarProducto[linea.estandarCodigo.Trim()];
                //}
                invoiceLine.StandardItemIdentification_SchemeAgencyID = linea.EstandarCodigoID.Trim();
                invoiceLine.StandardItemIdentification_SchemeAgencyName = linea.EstandarCodigoNombre.Trim();
                //invoiceLine.StandardItemIdentification_SchemeDataURI = linea.estandarCodigoIdentificador.Trim();
                //invoiceLine.StandardItemIdentification_ExtendedID = linea.estandarSubCodigoProducto.Trim();
            }
            return invoiceLine;
        }
    }
}
