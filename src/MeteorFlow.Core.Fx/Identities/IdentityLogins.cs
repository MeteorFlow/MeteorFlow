using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Fx.Models;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Fx.Identities;

public class IdentityLogins : IdentityUserLogin<Guid>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public virtual IdentityBase Identity { get; set; }
    public DateTimeOffset LoggedOn { get; set; } = DateTimeOffset.Now;
}