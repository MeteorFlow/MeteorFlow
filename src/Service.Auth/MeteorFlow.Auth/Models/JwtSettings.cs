namespace MeteorFlow.Auth.Models;

public class JwtSettings
{
    public required string SecretKey { get; set; }
    public required string EncryptKey { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
    public int NotBeforeMinutes { get; set; }
    public int ExpirationMinutes { get; set; }
}