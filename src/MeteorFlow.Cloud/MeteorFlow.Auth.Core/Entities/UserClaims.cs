using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Auth.Core.Entities;

public class UserClaims : IdentityUserClaim<Guid>
{
    public virtual User Identity { get; set; }
}