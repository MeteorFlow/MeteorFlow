using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Fx.Identities;
using MeteorFlow.Core.Fx.Models;
using MeteorFlow.Domain;

namespace MeteorFlow.Core.Entities;

public class Users: IdentityBase
{
    public Gender Gender { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    
    [Required, ForeignKey(nameof(Tenant))]
    public Guid DepartmentId { get; set; }
    public virtual required Tenants Tenant { get; set; }
}