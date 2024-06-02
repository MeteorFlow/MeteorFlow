using MeteorFlow.Fx.Entities;

namespace MeteorFlow.FormBuilder.Entities;

public class FormElements: Entity<Guid>
{
    public required string Renderer { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Icon { get; set; }
}