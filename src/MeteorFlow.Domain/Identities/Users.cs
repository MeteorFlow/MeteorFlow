using MeteorFlow.Fx.Models;

namespace MeteorFlow.Domain;

public class Users: MeteorIdentities
{
    public string AvatarUrl { get; set; } = string.Empty;
    public string AddressJson { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;

    
    public Gender Gender { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    
    public Tenants Tenant { get; set; }
}