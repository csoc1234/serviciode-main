namespace Login.Application.Dto
{
    public class TokenJwtDto
    {
        public string Token { get; set; }

        public DateTime PasswordExpiration { get; set; }
    }
}
