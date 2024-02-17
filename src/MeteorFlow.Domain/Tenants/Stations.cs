using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Domain.Tenants;

public class Stations : BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
}