using MeteorFlow.Fx.Entities;

namespace MeteorFlow.FormBuilder.Models;

public class FormElement: JsonBase<Guid>
{
    public string Renderer { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Icon { get; set; }
}