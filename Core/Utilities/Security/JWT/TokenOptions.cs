namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public int AccesTokenExpiration { get; set; }
        public string SecurityKey { get; set; } = string.Empty;
    }
}
