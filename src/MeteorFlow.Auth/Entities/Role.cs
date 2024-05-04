using MeteorFlow.Fx.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Auth.Entities;

public class Role : Entity<Guid>
{
    public required string Name { get; set; }

    public required string NormalizedName { get; set; }

    public required string ConcurrencyStamp { get; set; }
    public ICollection<RoleClaims> Claims { get; set;}
    public ICollection<UserRole> UserRoles { get; set; }
}