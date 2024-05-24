using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Domain.App;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.FormBuilder.Entities;

public class FormBlocks: Entity<Guid>
{
    [ForeignKey(nameof(Element))]
    public Guid ElementId { get; set; }
    public required FormElements Element { get; set; }
    public int Order { get; set; }
    
    // Display
    public string DisplayName { get; set; }
    public string Placeholder { get; set; }
    public string Tooltip { get; set; }
    public string Prepend { get; set; }
    public string Append { get; set; }
    
    // Others
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    
    public Guid VersionId { get; set; }
}