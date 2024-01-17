using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Domain;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Entities;

public class Account : IdentityUser<int>
{
    public AccountType Type { get; set; }
    public override string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    [ForeignKey("User")]
    public int UserId { get; set; }
    public virtual Profiles? User { get; set; }
    public ICollection<AccountClaim> Claims { get; set; }
    public ICollection<AccountRole> AccountRoles { get; set; }
    public ICollection<AccountLogins> AccountLogins { get; set; }
    public ICollection<AccountTokens> AccountTokens { get; set; }
    public ICollection<AccountRefreshTokens> AccountRefreshTokens { get; set; }
    public string AdditionalPropertiesJson { get; set; } = string.Empty;
}