using MeteorFlow.Domain.Commons;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Domain.App;

public class AppSettings : JsonBase<Guid>
{
    public string Name { get; set; }
    public string Value { get; set; } = String.Empty;
    public string Description { get; set; } = String.Empty;
    public string Type { get; set; } = String.Empty;
}