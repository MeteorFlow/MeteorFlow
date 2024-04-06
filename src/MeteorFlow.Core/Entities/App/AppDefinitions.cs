using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Fx.Commons;
using MeteorFlow.Core.Fx.Models;

namespace MeteorFlow.Core.Entities.App;

public class AppDefinitions: Base<Guid>, IObject, IRecoverable
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    
    [ForeignKey(nameof(BaseDefinition))]
    public Guid BaseDefinitionId { get; set; }
    public virtual AppDefinitions? BaseDefinition { get; set; }
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
    public DateTimeOffset? DeleteTime { get; set; }
}