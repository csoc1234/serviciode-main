using APIGenerateUBL.Domain.Catalog;
using APIGenerateUBL.Domain.DocumentFill.Acounting;
using APIGenerateUBL.Domain.DocumentFill.Extensions;
using APIGenerateUBL.Domain.DocumentFill.Lines;
using APIGenerateUBL.Domain.DocumentFill.Payment;
using APIGenerateUBL.Domain.DocumentFill.Totals;
using APIGenerateUBL.Domain.Interface;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;
using DocumentoEquivalente.Modelo.Supplier;
using Newtonsoft.Json;

namespace APIGenerateUBL.Domain.DocumentFill
{
    public class InvoiceFill : IInvoiceFill
    {
        private readonly IConfiguration _configuration;

        public InvoiceFill(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseDocument21 Set(FacturaGeneral request, Emisor emisor)
        {
            //Limpieza de Serializado

            string? requestJson = JsonConvert.SerializeObject(request).Replace(":null", ":\"\"");

            request = JsonConvert.DeserializeObject<FacturaGeneral>(requestJson);

            BaseDocument21 doc = new BaseDocument21();

            doc.TypeDocument = "Invoice";

            doc.UBLVersionID = DocumentBuildCO.Common.Catalog.UBLVersionID21;

            doc.CustomizationID = request.TipoOperacion.Trim();

            doc.DocumentCurrencyCode = request.Moneda.Trim();

            doc.ID = request.ConsecutivoDocumento.Trim();

            doc.UUID_schemeName = "CUDE-SHA384";

            doc.ProfileID = ProfileType.GetValue(request.TipoDocumento.Trim());

            doc.InvoiceTypeCode = request.TipoDocumento.Trim();

            DateTime fechaEmision;

            DateTime.TryParse(request.FechaEmision.Trim(), out fechaEmision);

            doc.IssueDate = fechaEmision;

            doc.IssueTime = fechaEmision;

            Int32.TryParse(request.TotalProductos.Trim(), out int totalProductos);
            doc.LineCountNumeric = totalProductos;

            doc.Note = new List<String>();

            doc.Extensible = new List<ExtensiblesNote>();

            if (request.InformacionAdicional != null)
                foreach (String row in request.InformacionAdicional)
                {
                    if (!string.IsNullOrEmpty(row))
                        doc.Extensible.Add(new ExtensiblesNote { Type = "Text", Value = row });
                }

            //Definicion de Ambiente
            String environment = (emisor.Ambiente == "1") ? "1" : "2";

            doc.UUID_schemeID = environment;

            //1 - Produccion
            //2 - Pruebas
            doc.ProfileExecutionID = environment;

            //AccountingSupplierParty
            doc.AcountingSupplierParty = SupplierFill.Set(emisor);

            //AccountingCustomerParty
            doc.AccountingCustomerParty = CustomerFill.Set(request);

            //Payment
            doc.PaymentMeans = PaymentMeansFill.Set(request);

            //PrepaidPayment
            doc.PrepaidPayment = PrepaidPaymentFill.Set(request);

            //PaymentExchangeRate
            doc.PaymentExchangeRate = PaymentExchangeRateFill.Set(request);

            //PaymentAlternativeExchangeRateFill
            doc.PaymentAlternativeExchangeRate = PaymentAlternativeExchangeRateFill.Set(request);

            //TaxTotal
            doc.TaxTotal = TaxTotalFill.SetTaxTotals(request.ImpuestosGenerales, request.ImpuestosTotales, request.Moneda);

            //WithholdingTaxTotal
            doc.WithholdingTaxTotal = WithholdingTaxTotalFill.SetTaxTotal(request.ImpuestosGenerales, request.ImpuestosTotales, request.Moneda);

            //AllowanceCharge
            doc.AllowanceCharge = AllowanceChargeFill.Set(request.CargosDescuentos, request.Moneda);

            //LegalMonetaryTotal
            doc.LegalMonetaryTotal = LegalMonetaryTotalFill.Set(request);

            //InvoiceLine
            doc.InvoiceLine = InvoiceLineFill.Set(request, emisor);

            doc.DianExtensions = DianExtensionFill.Set(request, emisor, _configuration);

            return doc;
        }
    }
}
