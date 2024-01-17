using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Entities;

public class AccountTokens : IdentityUserToken<int>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public Account Account { get; set; }
    public DateTimeOffset GeneratedTime { get; set; } = DateTimeOffset.Now;
}