using System.ComponentModel.DataAnnotations;

namespace MeteorFlow.Core.Fx.Commons;

public interface IVersionControl
{
    [Required]
    public int MajorVersion { get; set; }
    [Required]
    public int MinorVersion { get; set; }
    public int PatchVersion { get; set; }
    public DateTimeOffset Timestamp { get; set; }
}