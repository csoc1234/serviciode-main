using Newtonsoft.Json;

namespace Login.Application.Dto
{
    public class LoginRequest
    {
        [JsonProperty("user", Required = Required.Always)]
        public string User { get; set; }

        [JsonProperty("password", Required = Required.Always)]
        public string Password { get; set; }
    }
}
