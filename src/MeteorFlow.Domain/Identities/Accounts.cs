using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Domain;

public class Accounts : BaseEntity<int>
{
    public virtual AccountType Type { get; set; } = AccountType.Undefined;

    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public Profiles Profile { get; set; }
}

public class LoginInfo
{
    public string Name { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}