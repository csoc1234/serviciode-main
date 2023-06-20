using APIComunicationDIAN.Common;
using APIComunicationDIAN.Domain.Enum;
using APIComunicationDIAN.Infraestructure.Interface;
using ServiceDIAN;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.ServiceModel.Channels;

namespace APIComunicationDIAN.Infraestructure.DianConnection
{
    public class DianClient : IDianClient
    {
        private readonly IConfiguration _configuration;
        private readonly ICaching _caching;
        private const string key = "xxxxxxxxxxxxxxxxxxxxx";

        public DianClient(IConfiguration configuration, ICaching caching)
        {
            _configuration = configuration;
            _caching = caching;
        }

        public IWcfDianCustomerServices Connection(EnvironmentEnum environment)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                String? urlDian = environment == EnvironmentEnum.Production ? _configuration["url:UrlProduction"] : _configuration["url:UrlHabilitation"];

                WSHttpBinding binding = new WSHttpBinding();
                binding.Security.Mode = SecurityMode.TransportWithMessageCredential;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
                binding.Security.Message.ClientCredentialType = MessageCredentialType.Certificate;
                binding.Security.Message.EstablishSecurityContext = false;
                binding.Security.Message.AlgorithmSuite = System.ServiceModel.Security.SecurityAlgorithmSuite.Basic256Sha256;

                //Bindigns configurations
                binding.MaxReceivedMessageSize = long.Parse(_configuration["bindings:maxReceivedMessageSize"]);
                binding.MaxBufferPoolSize = long.Parse(_configuration["bindings:maxBufferPoolSize"]);
                binding.CloseTimeout = TimeSpan.Parse(_configuration["bindings:closeTimeout"]);
                binding.OpenTimeout = TimeSpan.Parse(_configuration["bindings:openTimeout"]);
                binding.ReceiveTimeout = TimeSpan.Parse(_configuration["bindings:receiveTimeout"]);
                binding.SendTimeout = TimeSpan.Parse(_configuration["bindings:sendTimeout"]);

                EndpointAddress endpoint = new EndpointAddress(urlDian);

                WcfDianCustomerServicesClient clientSoap = new WcfDianCustomerServicesClient(binding, endpoint);

                BindingElementCollection elementsc = clientSoap.Endpoint.Binding.CreateBindingElements();

                elementsc.Find<SecurityBindingElement>().SecurityHeaderLayout = SecurityHeaderLayout.Lax;

                byte[] certificate;

                if (_caching.TryGetValue(_configuration["certificate:file"], out string cert64))
                {
                    certificate = Convert.FromBase64String(cert64);
                }
                else
                {
                    string pathCertificate = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + Path.DirectorySeparatorChar + "Certificate" + Path.DirectorySeparatorChar + _configuration["certificate:file"];
                    certificate = File.ReadAllBytes(pathCertificate);

                    _caching.Set(_configuration["certificate:file"], Convert.ToBase64String(certificate));
                }

                clientSoap.ClientCredentials.ClientCertificate.Certificate = new X509Certificate2(certificate, String64.Base64Decode(key), X509KeyStorageFlags.MachineKeySet | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.Exportable);

                CustomBinding custom = new CustomBinding(elementsc);
                clientSoap.Endpoint.Binding = custom;

                return clientSoap;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Connection:" + ex.GetType().Name + ex.InnerException);
                return null;
            }
        }
    }
}
