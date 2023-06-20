using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;

namespace APIGenerateUBL.Domain.DocumentFill.Totals
{
    public static class AllowanceChargeFill
    {
        public static List<AllowanceCharge>? Set(List<CargosDescuentos> cargosDescuentos, String moneda)
        {
            List<AllowanceCharge> allowanceCharges = new List<AllowanceCharge>();

            try
            {
                if (cargosDescuentos != null)
                {
                    foreach (CargosDescuentos cargo in cargosDescuentos)
                    {
                        if (cargo != null)
                        {
                            AllowanceCharge charge = new AllowanceCharge();

                            int chargeID = 0;
                            Int32.TryParse(cargo.secuencia.Trim(), out chargeID);
                            charge.ID = chargeID;

                            charge.ChargeIndicator = cargo.indicador.Trim().Equals("1") ? true : false;
                            charge.AllowanceChargeReasonCode = cargo.codigo.Trim();
                            charge.AllowanceChargeReason = cargo.descripcion.Trim();
                            charge.MultiplierFactorNumeric = UtilitiesString.ConvertDecimalNullable(cargo.porcentaje);
                            charge.Amount = UtilitiesString.ConvertDecimal(cargo.monto);
                            charge.BaseAmount = UtilitiesString.ConvertDecimal(cargo.montoBase);
                            charge.Amount_CurrencyID = moneda;
                            charge.BaseAmount_CurrencyID = moneda;

                            allowanceCharges.Add(charge);
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return allowanceCharges;
        }
    }
}
