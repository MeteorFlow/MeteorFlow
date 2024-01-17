using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Domain;

public class Profiles : BaseEntity<int>
{
    public string FullName { get; set; } = string.Empty;
    public Gender Gender { get; set; } = Gender.Female;
    public DateTimeOffset DateOfBirth { get; set; } = DateTimeOffset.Now;
    public string AvatarUrl { get; set; } = string.Empty;
    public Address Address { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
}