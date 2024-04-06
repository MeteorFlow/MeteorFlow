
using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Fx.Commons;
using MeteorFlow.Core.Fx.Models;

namespace MeteorFlow.Core.Entities.Forms;

public class FormElements: JsonBase<Guid>, IObject
{
    public required string Renderer { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public string? Icon { get; set; }
    
    [ForeignKey(nameof(Schema))]
    public Guid SchemaId { get; set; }
    public ElementSchemas? Schema { get; set; }
}