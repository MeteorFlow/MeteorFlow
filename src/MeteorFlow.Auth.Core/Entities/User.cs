using System.ComponentModel.DataAnnotations;
using MeteorFlow.Fx.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Auth.Core.Entities;

public class User: Entity<Guid>
{
    [MaxLength(Int32.MaxValue)]
    public string UserName { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string NormalizedUserName { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string Email { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string NormalizedEmail { get; set; }

    public bool EmailConfirmed { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string PasswordHash { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string PhoneNumber { get; set; }

    public bool PhoneNumberConfirmed { get; set; }

    public bool TwoFactorEnabled { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string ConcurrencyStamp { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string SecurityStamp { get; set; }

    public bool LockoutEnabled { get; set; }

    public DateTimeOffset? LockoutEnd { get; set; }

    public int AccessFailedCount { get; set; }

    public Guid Auth0UserId { get; set; }

    public Guid AzureAdB2CUserId { get; set; }

    public IList<UserTokens> Tokens { get; set; }

    public IList<UserClaims> Claims { get; set; }

    public IList<UserRole> UserRoles { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string AvatarUrl { get; set; } = string.Empty;
    [MaxLength(Int32.MaxValue)]
    public string AddressJson { get; set; } = string.Empty;
    [MaxLength(Int32.MaxValue)]
    public string AdditionalPropertiesJson { get; set; } = string.Empty;
}