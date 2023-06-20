namespace Login.Infrastructure.Logger.Models
{
    public class LogRequest
    {
        public string Method { get; set; }
        public string Api { get; set; }
        public ApplicationType Application { get; set; }
    }

    public enum ApplicationType
    {
        None = 0,
        Portal = 1,
        Integracion = 2,
        AppMovil = 3
    }
}
