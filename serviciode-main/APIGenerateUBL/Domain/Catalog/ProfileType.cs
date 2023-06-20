namespace APIGenerateUBL.Domain.Catalog
{
    public class ProfileType
    {
        public static string GetValue(string key)
        {
            return key.Trim() switch
            {
                "20" => "DIAN 2.1: Documento Equivalente POS",
                "25" => "DIAN 2.1: Boleta de ingreso a espectáculos públicos",
                "30" => "DIAN 2.1: Documento en juegos localizados - relación diaria de control de ventas",
                "35" => "DIAN 2.1: Documento Equivalente Tiquete de Transporte Terrestre de Pasajeros",
                "40" => "DIAN 2.1: Documento Equivalente para el Cobro de Peajes",
                "45" => "DIAN 2.1: Extracto",
                "50" => "DIAN 2.1: Documento equivalente – Tiquete o boleto aéreo de pasajeros",
                "55" => "DIAN 2.1: Comprobante de liquidación de operaciones expedido por Bolsa de Valores y operaciones de la bolsa agropecuaria y de otros commodities",
                "60" => "DIAN 2.1: Documento Equivalente SPD",
                "94" => "DIAN 2.1: Nota de ajuste al documento equivalente",
                "04" => "",
                _ => "",
            };
        }
    }
}
