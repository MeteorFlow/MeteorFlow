
using MeteorFlow.Fx.Models;

namespace MeteorFlow.Domain;

public class Tenants: MeteorIdentities
{
    public Tenants BaseTenant { get; set; } = null;
    public ICollection<Users> Users { get; set; } = new List<Users>();
}