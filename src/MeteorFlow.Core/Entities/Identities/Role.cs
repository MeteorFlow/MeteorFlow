using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Entities;

public class Roles : IdentityRole<int>
{
    public string DisplayName { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
    public ICollection<RoleClaims> Claims { get; set; }
    public ICollection<AccountRole> Users { get; set; }
}