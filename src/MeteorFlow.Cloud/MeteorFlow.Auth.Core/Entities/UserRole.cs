using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Auth.Core.Entities;

public class UserRole : IdentityUserRole<Guid>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public User Account { get; set; }
    public Roles Role { get; set; }
    public DateTime CreatedUserRoleDate { get; set; }
}