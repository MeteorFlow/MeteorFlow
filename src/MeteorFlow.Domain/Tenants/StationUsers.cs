using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Domain.Tenants;

public class StationUsers : BaseEntity<int>
{
    public Stations Station { get; set; }
    public Profiles Profile { get; set; }
}