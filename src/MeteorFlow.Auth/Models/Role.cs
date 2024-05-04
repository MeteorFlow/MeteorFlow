using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Auth.Models;

public class Role: Base<Guid>
{
    public string Name { get; set; }

    public string NormalizedName { get; set; }

    public string ConcurrencyStamp { get; set; }
}