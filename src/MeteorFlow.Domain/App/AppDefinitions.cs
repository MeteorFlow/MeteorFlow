
using MeteorFlow.Fx.Commons;
using MeteorFlow.Fx.Models;

namespace MeteorFlow.Domain.App;

public class AppDefinitions: Base<Guid>, IObject
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Icon Icon { get; set; }
    public AppDefinitions BaseDefinition { get; set; } = null;
}