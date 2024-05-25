using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Domain.App;

public class AppVersionControls: JsonBase<Guid>, IVersionControl
{
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
    public int PatchVersion { get; set; }
    public DateTimeOffset Timestamp { get; set; }
}