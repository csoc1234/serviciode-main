using APIGenerateUBL.Transversal.Utils;
using DocumentBuildCO.DocumentClass.UBL2._1;
using DocumentoEquivalente.Modelo.Document;

namespace APIGenerateUBL.Domain.DocumentFill.Acounting
{
    public static class AddressFill
    {
        public static Address? Set(Direccion dir)
        {
            Address address = null;

            if (dir != null)
            {
                address = new Address
                {
                    ID = dir.Municipio.Trim(),
                    AddressLine_Line = dir.direccion.Trim(),
                    CityName = dir.Ciudad.Trim(),
                    CountrySubentity = dir.Departamento.Trim(),
                    CountrySubentityCode = dir.CodigoDepartamento.Trim(),
                    Country_LanguageID = (!String.IsNullOrWhiteSpace(dir.Lenguaje.Trim())) ? dir.Lenguaje.Trim() : "es",
                    Country_Name = Catalogo.GetValue(dir.Pais.Trim(), ObjectValues.CatPaises),
                    Country_IdentificationCode = dir.Pais.Trim(),
                    PostalZone = dir.ZonaPostal.Trim()
                };
            }

            return address;
        }
    }
}
