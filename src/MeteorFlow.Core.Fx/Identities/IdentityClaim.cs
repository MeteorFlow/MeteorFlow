using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Fx.Identities;

public class IdentityClaims : IdentityUserClaim<Guid>
{
    public virtual IdentityBase Identity { get; set; }
}