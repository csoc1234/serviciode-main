using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;

namespace APIGenerateUBL.Domain.DocumentFill.Payment
{
    public static class PrepaidPaymentFill
    {
        public static PrepaidPayment? Set(FacturaGeneral request)
        {
            if (request.Anticipos != null)
            {
                PrepaidPayment prepaid = new PrepaidPayment();

                foreach (Anticipos? row in request.Anticipos)
                {
                    if (row != null)
                    {
                        PrepaidPayment prepaidPayment = new PrepaidPayment();
                        prepaidPayment.ID = row.id;
                        prepaidPayment.InstructionID = row.instrucciones;
                        prepaidPayment.PaidAmount = UtilitiesString.ConvertDecimalNullable(row.montoPagado);
                        prepaidPayment.PaidAmount_currencyID = request.Moneda;
                        prepaidPayment.PaidDate = UtilitiesString.ConvertDateTimeNullable(row.fechadePago);
                        prepaidPayment.PaidTime = UtilitiesString.ConvertDateTimeNullable(row.horaDePago);
                        prepaidPayment.ReceivedDate = UtilitiesString.ConvertDateTimeNullable(row.fechaDeRecibido);

                        prepaid = prepaidPayment;
                        break;
                    }
                }

                return prepaid;
            }
            else
            {
                return null;
            }
        }
    }
}
