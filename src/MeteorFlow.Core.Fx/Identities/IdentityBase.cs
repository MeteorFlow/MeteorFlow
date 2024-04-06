using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Fx.Identities;

public class IdentityBase: IdentityUser<Guid>
{
    [MaxLength(Int32.MaxValue)]
    public string AvatarUrl { get; set; } = string.Empty;
    [MaxLength(Int32.MaxValue)]
    public string AddressJson { get; set; } = string.Empty;
    [MaxLength(Int32.MaxValue)]
    public string AdditionalPropertiesJson { get; set; } = string.Empty;
}