using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Entities;

public class RoleClaims : IdentityRoleClaim<int>
{
    public DateTimeOffset CreatedClaim { get; set; } = DateTimeOffset.Now;
    public virtual Roles Role { get; set; }
}