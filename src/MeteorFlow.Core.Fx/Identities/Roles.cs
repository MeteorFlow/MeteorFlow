using MeteorFlow.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Fx.Identities;

public class Roles : IdentityRole<Guid>
{
    public string DisplayName { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public ICollection<RoleClaims> Claims { get; set; }
    public ICollection<IdentityRole> Users { get; set; }
}