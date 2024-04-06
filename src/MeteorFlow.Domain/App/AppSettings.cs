using MeteorFlow.Fx.Commons;
using MeteorFlow.Fx.Models;

namespace MeteorFlow.Domain.App;

public class AppSettings : JsonBase<Guid>, IObject
{
    public string Name { get; set; }
    public string Value { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;

    public Icon Icon { get; set; }
    public string Type { get; set; } = String.Empty;
}