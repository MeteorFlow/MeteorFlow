using MeteorFlow.Fx.Entities;

namespace MeteorFlow.FormBuilder.Core.Models;

public class ElementSchemas: JsonBase<Guid>
{
    public string Name { get; set; }
    public string Type { get; set; }
    public InputType InputType { get; set; }
    public bool Searchable { get; set; }
    public bool Required { get; set; }
    public bool ReadOnly { get; set; }
    public bool Autocomplete { get; set; }
}