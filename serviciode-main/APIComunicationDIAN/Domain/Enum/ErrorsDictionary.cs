namespace APIComunicationDIAN.Domain.Enum
{
    public static class ErrorsDictionary
    {
        public readonly static Dictionary<int, string> Errors = new Dictionary<int, string>()
        {
            {0, "Procesado exitosamente." },
            { 1, "NameResolutionFailure: El servicio de resolución de nombres no pudo resolver el nombre de host." },
            { 2, "ConnectFailure: No se pudo establecer contacto con el punto de servicio remoto en el nivel de transporte." },
            { 3, "ReceiveFailure: No se recibió una respuesta completa del servidor remoto." },
            { 4, "SendFailure: No se pudo enviar una solicitud completa al servidor remoto." },
            { 5, "PipelineFailure: La solicitud era una solicitud canalizada y la conexión se cerró antes de recibir la respuesta." },
            { 6, "RequestCanceled: Se ha cancelado la solicitud, el System.Net.WebRequest.Abort se llamó al método, o se produjo un error no clasificable. Este es el valor predeterminado de la clase System.Net.WebException.Status." },
            { 7, "ProtocolError: La respuesta recibida desde el servidor completara pero ha indicado un error de nivel de protocolo. Por ejemplo, un error de protocolo HTTP como 401 Acceso denegado utilizaría este estado." },
            { 8, "ConnectionClosed: La conexión se cerró prematuramente." },
            { 9, "TrustFailure: No se pudo validar un certificado de servidor." },
            { 10, "SecureChannelFailure: Se produjo un error al establecer una conexión mediante SSL." },
            { 11, "ServerProtocolViolation: La respuesta del servidor no fue una respuesta HTTP válida." },
            { 12, "KeepAliveFailure: La conexión para una solicitud que especifica el encabezado Keep-alive se cerró inesperadamente." },
            { 13, "Pending: Está pendiente una solicitud asincrónica interna." },
            { 14, "Timeout: Se recibió ninguna respuesta durante el período de tiempo de espera para una solicitud." },
            { 15, "ProxyNameResolutionFailure: El servicio de resolución de nombres no pudo resolver el nombre de host del proxy." },
            { 16, "UnknownError: Se ha producido una excepción de tipo desconocido." },
            { 17, "MessageLengthLimitExceeded: Se recibió un mensaje que superaba el límite especificado al enviar una solicitud o recibir una respuesta del servidor." },
            { 18, "CacheEntryNotFound: No se encontró la entrada de caché especificada." },
            { 19, "RequestProhibitedByCachePolicy: La directiva de caché no permitió la solicitud. En general, esto ocurre cuando una solicitud no almacenable en caché y la directiva en vigor prohíbe enviar la solicitud al servidor. Podría recibir este estado si un método de solicitud implica la presencia de un cuerpo de solicitud, un método de solicitud requiere la interacción directa con el servidor o una solicitud contiene un encabezado condicional." },
            { 20, "RequestProhibitedByProxy: El proxy no permitió esta solicitud." },
            { 21, "CryptographicException: Ocurrió un error al cagar el certificado local del equipo." },
            { 100, "Ha ocurrido una excepción"},
            { 101, "El request es inválido."},
            { 102, "No se pudo comprobar la integridad del archivo."},
            { 103, "La respuesta de la DIAN es nula."},
            { 104, "El tamaño del .zip generado es inválido." },
            { 105, "Ocurrió un error al consumir el método de entrega a la DIAN."},
            { 199, "La consulta no arrojó numeraciones."},
            { 200, "Procesado exitosamente." },
            { 201, "Procesado. Los detalles se especifican en la lista de 'observaciones'." },
            { 202, "Procesado. La DIAN no retornó el Application Response." },
            { 203, "Error. La entrega del documento falló luego de {0} intentos." },
            { 204, "Alerta. Documento entregado luego de {0} intento(s)." },
        };
    }
}
