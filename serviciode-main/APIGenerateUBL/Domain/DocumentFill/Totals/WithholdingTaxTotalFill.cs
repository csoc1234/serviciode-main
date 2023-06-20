using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;

namespace APIGenerateUBL.Domain.DocumentFill.Totals
{
    public static class WithholdingTaxTotalFill
    {

        public static List<WithholdingTaxTotal>? SetTaxTotal(List<FacturaImpuestos> impuestos, List<ImpuestosTotales> impuestosTotales, String moneda)
        {
            List<WithholdingTaxTotal> WithholdingTaxTotal = new List<WithholdingTaxTotal>();

            if (impuestosTotales != null)
            {
                IEnumerable<string>? ListaImpuestos = impuestosTotales.Where(p =>
                    p.codigoTOTALImp.Equals("05") ||
                    p.codigoTOTALImp.Equals("06") ||
                    p.codigoTOTALImp.Equals("07")
                    ).Select(f => f.codigoTOTALImp).Distinct();

                // Filtro de los totales
                if (ListaImpuestos != null)
                {
                    foreach (string? rowTax in ListaImpuestos)
                    {
                        if (rowTax != null)
                        {
                            ImpuestosTotales? impuestoTotal = impuestosTotales.Where(r => r.codigoTOTALImp == rowTax).FirstOrDefault();

                            List<FacturaImpuestos>? impuestosLista = impuestos.Where(r => r.codigoTOTALImp == rowTax).ToList();

                            if (impuestosLista != null)
                            {
                                if (impuestosLista.Count > 0)
                                {
                                    SetTaxSubtotals(impuestosLista, impuestoTotal, ref WithholdingTaxTotal, moneda);
                                }
                                else
                                {
                                    throw new System.Exception("Se envio solo el total de la retencion " + rowTax + " pero se esperaba el subtotal de la retencion enviada.");
                                }
                            }
                            else
                            {
                                throw new System.Exception("Se envio solo el total de la retencion " + rowTax + " pero se esperaba el subtotal de la retencion enviada.");
                            }
                        }
                    }
                }
            }

            return WithholdingTaxTotal;
        }

        public static void SetTaxSubtotals(IEnumerable<FacturaImpuestos> impuestos, ImpuestosTotales total, ref List<WithholdingTaxTotal> listwithholdings, string moneda)
        {
            List<TaxSubtotal> listsubtotal = new List<TaxSubtotal>();
            WithholdingTaxTotal withholding = new WithholdingTaxTotal();
            if (impuestos != null)
            {
                foreach (FacturaImpuestos retencion in impuestos)
                {
                    TaxSubtotal subtotal = new TaxSubtotal();
                    subtotal.TaxAmount = UtilitiesString.ConvertDecimal(retencion.valorTOTALImp);
                    subtotal.TaxAmount_currencyID = moneda;
                    subtotal.TaxScheme_ID = retencion.codigoTOTALImp.Trim();
                    subtotal.TaxScheme_Name = ObjectValues.DiccionarioTipoDeImpuesto.TryGetValue(retencion.codigoTOTALImp.Trim(), out string valorImpuesto) == true ? valorImpuesto : "";
                    subtotal.Percent = UtilitiesString.ConvertDecimalNullable(retencion.porcentajeTOTALImp);
                    subtotal.TaxableAmount = UtilitiesString.ConvertDecimal(retencion.baseImponibleTOTALImp);
                    subtotal.TaxableAmount_currencyID = moneda;

                    listsubtotal.Add(subtotal);
                }
            }
            if (total != null)
                withholding.TaxAmount = UtilitiesString.ConvertDecimal(total.montoTotal);
            withholding.TaxAmount_currencyID = moneda;
            withholding.TaxSubtotal = new List<TaxSubtotal>();
            withholding.TaxSubtotal = listsubtotal;
            listwithholdings.Add(withholding);
        }

    }
}
