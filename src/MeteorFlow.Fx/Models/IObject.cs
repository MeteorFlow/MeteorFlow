using MeteorFlow.Fx.Commons;

namespace MeteorFlow.Fx.Models;

public interface IObject
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Icon Icon { get; set; }
}