using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;

namespace APIGenerateUBL.Domain.DocumentFill.Totals
{
    public static class TaxTotalFill
    {
        public static List<TaxTotal>? SetTaxTotals(List<FacturaImpuestos> impuestos, List<ImpuestosTotales> impuestosTotales, String moneda)
        {
            List<TaxTotal> taxTotal = new List<TaxTotal>();

            if (impuestosTotales != null)
            {
                IEnumerable<object>? ListaImpuestos = impuestosTotales.Where(p =>
                    p.codigoTOTALImp.Equals("01") ||
                    p.codigoTOTALImp.Equals("02") ||
                    p.codigoTOTALImp.Equals("03") ||
                    p.codigoTOTALImp.Equals("04") ||
                    p.codigoTOTALImp.Equals("20") ||
                    p.codigoTOTALImp.Equals("21") ||
                    p.codigoTOTALImp.Equals("22") ||
                    p.codigoTOTALImp.Equals("23") ||
                    p.codigoTOTALImp.Equals("24") ||
                    p.codigoTOTALImp.Equals("25") ||
                    p.codigoTOTALImp.Equals("26") ||
                    p.codigoTOTALImp.Equals("ZY") ||
                    p.codigoTOTALImp.Equals("ZZ")
                    ).Select(f => f.codigoTOTALImp).Distinct();

                // Filtro de los totales
                if (ListaImpuestos != null)
                {
                    foreach (string rowTax in ListaImpuestos)
                    {
                        if (rowTax != null)
                        {
                            ImpuestosTotales? impuestoTotal = impuestosTotales.Where(r => r.codigoTOTALImp == rowTax).FirstOrDefault();

                            List<FacturaImpuestos>? impuestosLista = impuestos.Where(r => r.codigoTOTALImp == rowTax).ToList();

                            if (impuestosLista != null)
                            {
                                if (impuestosLista.Count > 0)
                                {
                                    SetTaxSubtotals(impuestosLista, impuestoTotal, ref taxTotal, moneda);
                                }
                                else
                                {
                                    throw new System.Exception("Se envio solo el total del impuesto " + rowTax + " pero se esperaba el subtotal del impuesto enviado.");
                                }
                            }
                            else
                            {
                                throw new System.Exception("Se envio solo el total del impuesto " + rowTax + " pero se esperaba el subtotal del impuesto enviado.");
                            }
                        }
                    }
                }
            }

            return taxTotal;
        }

        public static void SetTaxSubtotals(IEnumerable<FacturaImpuestos> impuestos, ImpuestosTotales total, ref List<TaxTotal> listTaxtotal, string moneda)
        {
            List<TaxSubtotal> listsubtotal = new List<TaxSubtotal>();
            TaxTotal taxes = new TaxTotal();
            if (impuestos != null)
            {
                foreach (FacturaImpuestos imp in impuestos)
                {
                    TaxSubtotal subtotal = new TaxSubtotal();
                    subtotal.TaxAmount = UtilitiesString.ConvertDecimal(imp.valorTOTALImp);
                    subtotal.TaxAmount_currencyID = moneda;
                    subtotal.BaseUnitMeasure = UtilitiesString.ConvertDecimalNullable(imp.unidadMedidaTributo);
                    subtotal.BaseUnitMeasure_unitCode = imp.unidadMedida.Trim();
                    subtotal.PerUnitAmount = UtilitiesString.ConvertDecimalNullable(imp.valorTributoUnidad);
                    subtotal.PerUnitAmount_currencyID = moneda;
                    subtotal.TaxScheme_ID = imp.codigoTOTALImp.Trim();
                    subtotal.TaxScheme_Name = ObjectValues.DiccionarioTipoDeImpuesto.TryGetValue(imp.codigoTOTALImp.Trim(), out string valorImpuesto) == true ? valorImpuesto : "";
                    subtotal.Percent = UtilitiesString.ConvertDecimalNullable(imp.porcentajeTOTALImp);
                    subtotal.TaxableAmount = UtilitiesString.ConvertDecimal(imp.baseImponibleTOTALImp);
                    subtotal.TaxableAmount_currencyID = moneda;

                    listsubtotal.Add(subtotal);
                }
            }

            if (total != null)
            {
                taxes.TaxAmount = UtilitiesString.ConvertDecimal(total.montoTotal);
                taxes.RoundingAmount = total.redondeoAplicado;
            }

            taxes.TaxAmount_currencyID = moneda;
            taxes.TaxSubtotal = new List<TaxSubtotal>();
            taxes.TaxSubtotal = listsubtotal;
            listTaxtotal.Add(taxes);
        }
    }
}
