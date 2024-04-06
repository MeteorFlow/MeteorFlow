using MeteorFlow.Fx.Commons;
using MeteorFlow.Fx.Models;

namespace MeteorFlow.Domain.App;

public class AppInstances: JsonBase<Guid>, IObject
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Icon Icon { get; set; }
}