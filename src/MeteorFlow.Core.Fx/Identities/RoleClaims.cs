using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Fx.Identities;

public class RoleClaims : IdentityRoleClaim<Guid>
{
    public DateTimeOffset CreatedClaim { get; set; } = DateTimeOffset.Now;
    public virtual Roles Role { get; set; }
}