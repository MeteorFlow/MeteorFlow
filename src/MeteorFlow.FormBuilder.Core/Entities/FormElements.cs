using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Domain.Commons;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.FormBuilder.Core.Entities;

public class FormElements: Entity<Guid>
{
    public required string Renderer { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Icon { get; set; }
    
    [ForeignKey(nameof(Schema))]
    public Guid SchemaId { get; set; }
    public ElementSchemas Schema { get; set; }
}