using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Fx.Commons;
using MeteorFlow.Core.Fx.Models;

namespace MeteorFlow.Core.Entities.App;

public class AppInstances: Base<Guid>, IObject, IRecoverable
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Icon { get; set; }
    
    [ForeignKey(nameof(AppliedVersion))]
    public Guid VersionId { get; set; }
    public virtual required AppVersionControls AppliedVersion { get; set; }
    
    public Guid TenantId { get; set; }
    
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
    public DateTimeOffset? DeleteTime { get; set; }
}