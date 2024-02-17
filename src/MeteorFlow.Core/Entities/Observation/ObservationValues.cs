using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Entities.Tenants;

namespace MeteorFlow.Core.Entities;

public class ObservationValues
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public byte Value { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset ModifiedAt { get; set; } = DateTimeOffset.Now;
    public DateTimeOffset? DeletedAt { get; set; }
    
    [ForeignKey("ObservationElement")]
    public int ElementId { get; set; }
    public virtual ObservationElements? Element { get; set; }
    
    [ForeignKey("Station")]
    public int StationId { get; set; }
    public virtual Stations? Station { get; set; }
}