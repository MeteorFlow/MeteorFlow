namespace MeteorFlow.Core.Fx.Identities;

public class Token
{
    public required string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public string TokenType { get; set; } = "Bearer";
    public int ExpiresIn { get; set; }
}