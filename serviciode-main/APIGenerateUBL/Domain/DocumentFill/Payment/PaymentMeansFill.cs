using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;

namespace APIGenerateUBL.Domain.DocumentFill.Payment
{
    public static class PaymentMeansFill
    {
        public static List<PaymentMeans>? Set(FacturaGeneral request)
        {
            List<PaymentMeans>? paymentMeans = new List<PaymentMeans>();

            if (request.MediosDePago != null)
            {
                foreach (MediosDePago? row in request.MediosDePago)
                {
                    if (row != null)
                    {
                        PaymentMeans paymentMean = new PaymentMeans
                        {
                            ID = row.metodoDePago.Trim(),
                            PaymentMeansCode = row.medioPago.Trim(),
                            PaymentDueDate = UtilitiesString.ConvertDateTimeNullable(row.fechaDeVencimiento),
                            PaymentID = row.numeroDeReferencia.Trim()
                        };

                        paymentMeans.Add(paymentMean);
                    }
                }
            }

            if (paymentMeans.Count > 0)
            {
                return paymentMeans;
            }
            else
            {
                throw new Exception("El documento debe contemplar al menos un Medio de Pago");
            }
        }
    }
}
