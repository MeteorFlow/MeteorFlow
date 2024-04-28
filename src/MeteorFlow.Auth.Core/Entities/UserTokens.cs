using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Auth.Core.Entities;

public class UserTokens : IdentityUserToken<Guid>
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public User Identity { get; set; }
    public DateTimeOffset GeneratedTime { get; set; } = DateTimeOffset.Now;
}