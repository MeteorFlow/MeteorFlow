using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Fx.Identities;

namespace MeteorFlow.Core.Entities;

public class Tenants: IdentityBase 
{
    [ForeignKey(nameof(BaseTenant))]
    public Guid? BaseTenantId { get; set; }
    public Tenants? BaseTenant { get; set; }
    public virtual ICollection<Users>? Users { get; set; }
}