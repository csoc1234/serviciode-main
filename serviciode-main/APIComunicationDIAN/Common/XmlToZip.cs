namespace APIComunicationDIAN.Common
{
    public static class XmlToZip
    {
        public static Byte[] Convert(String xmlBase64, String fileName)
        {
            try
            {
                //Decodifico y convierto a byte[] el string recibido en base64
                byte[] Xmldecoded = System.Convert.FromBase64String(xmlBase64);
                Ionic.Zip.ZipFile zip = new Ionic.Zip.ZipFile();
                MemoryStream ms = new MemoryStream();
                zip.AddEntry(fileName + ".xml", Xmldecoded);
                zip.Save(ms);
                ms.Seek(0, SeekOrigin.Begin);
                return ms.ToArray();
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }
    }
}
