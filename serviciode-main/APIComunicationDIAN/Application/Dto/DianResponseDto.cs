namespace APIComunicationDIAN.Application.Dto
{
    public class DianResponseDto
    {
        public int Codigo { get; set; }

        public String Mensaje { get; set; }

        public String MensajeExcepcion { get; set; }

        public List<String> TFHKAErrores { get; set; }

        public List<String> DIANErrores { get; set; }

        public List<String> DIANNotificaciones { get; set; }

        public String EstatusCodigo { get; set; }

        public String EstatusDescripcion { get; set; }

        public String EstatusMensaje { get; set; }

        public Boolean EsValido { get; set; }

        public String NombreArchivo { get; set; }

        public String Sesion { get; set; }

        public Boolean Entregado { get; set; }

        public String UUID { get; set; }

        public String TrackID { get; set; }

        public String DIANFechaHoraRespuesta { get; set; }

        public Byte[] ApplicationResponse { get; set; }

        public String CodigoEmisor { get; set; }
    }
}
