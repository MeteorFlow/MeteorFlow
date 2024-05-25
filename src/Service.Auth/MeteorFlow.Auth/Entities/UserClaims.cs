using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Auth.Entities;

public class UserClaims : IdentityUserClaim<Guid>
{
    public virtual User Identity { get; set; }
}