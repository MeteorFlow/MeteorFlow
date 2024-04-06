using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Fx.Identities;
using MeteorFlow.Core.Fx.Models;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Entities;

public class IdentityTokens : IdentityUserToken<Guid>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public IdentityBase Identity { get; set; }
    public DateTimeOffset GeneratedTime { get; set; } = DateTimeOffset.Now;
}