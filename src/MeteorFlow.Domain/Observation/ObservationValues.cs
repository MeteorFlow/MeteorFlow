using MeteorFlow.Domain.Tenants;
using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Domain;

public class ObservationValues: BaseEntity<int>
{
    public byte Value { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? DeletedAt { get; set; }
    
    public ObservationElements ObservationElement { get; set; }
    public Stations Station { get; set; }
}