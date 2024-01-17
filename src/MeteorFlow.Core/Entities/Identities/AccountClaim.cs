using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Entities;

public class AccountClaim : IdentityUserClaim<int>
{
    public virtual Account Account { get; set; }
}