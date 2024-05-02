using MeteorFlow.Domain.Commons;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.FormBuilder.Models;

public class FormBlocks: JsonBase<Guid>, IObject
{
    public string Name { get; set; }
    public FormElements Element { get; set; }
    
    // Display
    public string DisplayName { get; set; }
    public string Placeholder { get; set; }
    public string Tooltip { get; set; }
    public string Prepend { get; set; }
    public string Append { get; set; }
    
    // Others
    public string Description { get; set; }
    public Icon Icon { get; set; }
}