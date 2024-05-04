namespace MeteorFlow.Fx.Entities;

public interface IVersionControl
{
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
    public int PatchVersion { get; set; }
}