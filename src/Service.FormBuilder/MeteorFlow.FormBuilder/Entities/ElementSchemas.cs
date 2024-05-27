using MeteorFlow.FormBuilder.Models;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.FormBuilder.Entities;

public class ElementSchemas: Entity<Guid>
{
    public required string Name { get; set; }
    public required string Type { get; set; }
    public InputType InputType { get; set; }
    public bool Searchable { get; set; }
    public bool Required { get; set; }
    public bool ReadOnly { get; set; }
    public bool Autocomplete { get; set; }
}