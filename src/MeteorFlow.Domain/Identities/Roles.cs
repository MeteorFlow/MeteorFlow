
using MeteorFlow.Fx.Models;

namespace MeteorFlow.Domain;

public class Roles: Base<Guid>
{
    public string DisplayName { get; set; } = string.Empty;
    public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
}