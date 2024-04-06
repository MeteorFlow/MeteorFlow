namespace MeteorFlow.Fx.Models;

public abstract class MeteorIdentities: JsonBase<Guid>
{
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}