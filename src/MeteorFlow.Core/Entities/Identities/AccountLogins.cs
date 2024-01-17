using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Entities;

public class AccountLogins : IdentityUserLogin<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public virtual Account Account { get; set; }
    public DateTimeOffset LoggedOn { get; set; } = DateTimeOffset.Now;
}