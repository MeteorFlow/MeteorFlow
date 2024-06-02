using MeteorFlow.Domain.Commons;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.FormBuilder.Models;

public class FormBlock: JsonBase<Guid>, IObject
{
    public string Name { get; set; }
    public FormElement Element { get; set; }
    public ElementSchema Schema { get; set; }
    
    // Display
    public string DisplayName { get; set; }
    public string Placeholder { get; set; }
    public string Tooltip { get; set; }
    public string Prepend { get; set; }
    public string Append { get; set; }
    
    // Others
    public string Description { get; set; }
    public Icon Icon { get; set; }
    public Guid VersionId { get; set; }
}