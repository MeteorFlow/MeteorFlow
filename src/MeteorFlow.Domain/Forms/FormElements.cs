using MeteorFlow.Fx.Models;

namespace MeteorFlow.Domain.Forms;

public class FormElements: JsonBase<Guid>
{
    public string Renderer { get; set; }
    public string DisplayName { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Icon { get; set; }
    public ElementSchemas Schema { get; set; }
}