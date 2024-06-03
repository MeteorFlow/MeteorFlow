using MeteorFlow.Domain.Commons;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Domain.App;

public class AppInstances: JsonBase<Guid>, IObject
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Icon? Icon { get; set; }
}