using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Entities.Tenants;
using MeteorFlow.Domain;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Entities;

public class Account : IdentityUser<int>
{
    public AccountType Type { get; set; }
    public override string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;

    [ForeignKey("Profile")]
    public int ProfileId { get; set; }
    public virtual Profiles Profile { get; set; }
    
    [ForeignKey("Station")]
    
    public int StationId { get; set; }
    
    public virtual Stations? Station { get; set; }
    public ICollection<AccountClaim> Claims { get; set; }
    public ICollection<AccountRole> AccountRoles { get; set; }
    public ICollection<AccountLogins> AccountLogins { get; set; }
    public ICollection<AccountTokens> AccountTokens { get; set; }
    
    public ICollection<AccountRefreshTokens> AccountRefreshTokens { get; set; }
    
    [MaxLength(Int32.MaxValue)]
    public string AdditionalPropertiesJson { get; set; } = string.Empty;
}