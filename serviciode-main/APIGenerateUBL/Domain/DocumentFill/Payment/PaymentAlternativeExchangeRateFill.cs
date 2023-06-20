﻿using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;

namespace APIGenerateUBL.Domain.DocumentFill.Payment
{
    public static class PaymentAlternativeExchangeRateFill
    {
        public static PaymentAlternativeExchangeRate? Set(FacturaGeneral doc)
        {
            if (doc.TasaDeCambio != null)
            {
                PaymentAlternativeExchangeRate paymentExchangeRate = new PaymentAlternativeExchangeRate();

                paymentExchangeRate.SourceCurrencyCode = doc.TasaDeCambio.monedaOrigen.Trim();
                paymentExchangeRate.SourceCurrencyBaseRate = UtilitiesString.ConvertDecimalNullable(doc.TasaDeCambio.baseMonedaOrigen.Trim());
                paymentExchangeRate.TargetCurrencyCode = doc.TasaDeCambio.monedaDestino.Trim();
                paymentExchangeRate.TargetCurrencyBaseRate = UtilitiesString.ConvertDecimalNullable(doc.TasaDeCambio.baseMonedaDestino.Trim());
                paymentExchangeRate.CalculationRate = UtilitiesString.ConvertDecimalNullable(doc.TasaDeCambio.tasaDeCambio.Trim());
                paymentExchangeRate.Date = UtilitiesString.ConvertDateTimeNullable(doc.TasaDeCambio.fechaDeTasaDeCambio.Trim());

                return paymentExchangeRate;
            }
            else
            {
                return null;
            }
        }
    }
}
