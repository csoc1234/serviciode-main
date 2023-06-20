namespace Login.Domain.Entity
{
    public class TokenJwtUser
    {
        public string Token { get; set; }

        public DateTime PasswordExpiration { get; set; }
    }
}
