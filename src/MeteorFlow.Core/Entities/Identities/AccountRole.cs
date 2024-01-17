using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Entities;

public class AccountRole : IdentityUserRole<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public Account Account { get; set; }
    public Roles Role { get; set; }
    public DateTime CreatedUserRoleDate { get; set; }
}