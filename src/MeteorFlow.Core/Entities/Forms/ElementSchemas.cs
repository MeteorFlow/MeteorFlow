using MeteorFlow.Core.Fx.Models;

namespace MeteorFlow.Core.Entities.Forms;

public class ElementSchemas: JsonBase<Guid>
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public int InputType { get; set; }
    public bool Searchable { get; set; }
    public bool Required { get; set; }
    public bool ReadOnly { get; set; }
    public bool Autocomplete { get; set; }
}