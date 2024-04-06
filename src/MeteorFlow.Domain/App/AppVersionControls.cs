using MeteorFlow.Fx.Models;

namespace MeteorFlow.Domain.App;

public class AppVersionControls: JsonBase<Guid>
{
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
    public int PatchVersion { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    
}