
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteorFlow.Core.Entities;

public class AccountRefreshTokens
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    public virtual Account Account { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    public bool IsValid { get; set; }
}