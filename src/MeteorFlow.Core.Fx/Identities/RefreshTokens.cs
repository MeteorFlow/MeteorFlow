
using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Fx.Models;

namespace MeteorFlow.Core.Fx.Identities;

public class RefreshTokens
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    [ForeignKey(nameof(Identity))]
    public int IdentityId { get; set; }
    public virtual IdentityBase Identity { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    public bool IsValid { get; set; }
}