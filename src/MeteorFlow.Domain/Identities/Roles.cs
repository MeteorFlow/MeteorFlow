using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Domain;

public class Roles: BaseEntity<int>
{
    public string DisplayName { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
}