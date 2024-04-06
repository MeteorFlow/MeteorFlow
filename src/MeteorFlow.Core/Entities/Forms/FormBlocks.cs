using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Entities.App;
using MeteorFlow.Core.Fx.Commons;
using MeteorFlow.Core.Fx.Models;

namespace MeteorFlow.Core.Entities.Forms;

public class FormBlocks: JsonBase<Guid>, IObject
{
    [ForeignKey(nameof(Element))]
    public Guid ElementId { get; set; }
    public required FormElements Element { get; set; }
    public int Order { get; set; }
    
    // Display
    public string? DisplayName { get; set; }
    public string? Placeholder { get; set; }
    public string? Tooltip { get; set; }
    public string? Prepend { get; set; }
    public string? Append { get; set; }
    
    // Others
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    
    [ForeignKey(nameof(Version))]
    public Guid VersionId { get; set; }
    public required AppVersionControls Version { get; set; }
}