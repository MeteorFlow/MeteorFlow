using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Fx.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Auth.Entities;

public class UserTokens : Entity<Guid>
{
    public Guid UserId { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string LoginProvider { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string TokenName { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string TokenValue { get; set; }
    
    public DateTimeOffset GeneratedTime { get; set; } = DateTimeOffset.Now;

}