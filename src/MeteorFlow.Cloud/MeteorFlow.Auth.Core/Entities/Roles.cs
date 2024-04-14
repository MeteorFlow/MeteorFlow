using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Auth.Core.Entities;

public class Roles : IdentityRole<Guid>
{
    public string DisplayName { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public ICollection<RoleClaims> Claims { get; set; }
    public ICollection<UserRole> Users { get; set; }
}