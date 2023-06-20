using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;

namespace APIGenerateUBL.Domain.DocumentFill.Totals
{
    public static class LegalMonetaryTotalFill
    {
        public static LegalMonetaryTotal? Set(FacturaGeneral doc)
        {
            if (doc != null)
            {
                LegalMonetaryTotal monetaryTotal = new LegalMonetaryTotal
                {
                    LineExtensionAmount = UtilitiesString.ConvertDecimal(doc.TotalSinImpuestos),
                    PayableAmount = UtilitiesString.ConvertDecimal(doc.TotalMonto),
                    PayableRoundingAmount = UtilitiesString.ConvertDecimalNullable(doc.RedondeoAplicado),
                    PrepaidAmount = UtilitiesString.ConvertDecimalNullable(doc.TotalAnticipos),
                    TaxExclusiveAmount = UtilitiesString.ConvertDecimal(doc.TotalBaseImponible),
                    TaxInclusiveAmount = UtilitiesString.ConvertDecimal(doc.TotalBrutoConImpuesto),
                    ChargeTotalAmount = UtilitiesString.ConvertDecimalNullable(doc.TotalCargosAplicados),
                    AllowanceTotalAmount = UtilitiesString.ConvertDecimalNullable(doc.TotalDescuentos),
                    AllowanceTotalAmount_currencyID = doc.Moneda,
                    ChargeTotalAmount_currencyID = doc.Moneda,
                    LineExtensionAmount_currencyID = doc.Moneda,
                    PayableAmount_currencyID = doc.Moneda,
                    PayableRoundingAmount_currencyID = doc.Moneda,
                    PrepaidAmount_currencyID = doc.Moneda,
                    TaxExclusiveAmount_currencyID = doc.Moneda,
                    TaxInclusiveAmount_currencyID = doc.Moneda
                };

                return monetaryTotal;
            }
            else
            {
                throw new Exception("Los montos totales son obligatorios");
            }
        }
    }
}
