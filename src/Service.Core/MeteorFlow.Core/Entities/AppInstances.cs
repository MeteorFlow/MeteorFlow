using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Core.Entities;

public class AppInstances: Entity<Guid>, IEntityObject
{
    
    [Required, MaxLength(Utils.MaxDisplayNameLength)] 
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(Utils.MaxDescriptionLength)]
    public string Description { get; set; }  = string.Empty;
    
    [MaxLength(Utils.MaxMetadataLength)]
    public string Icon { get; set; } = string.Empty;
    
    [ForeignKey(nameof(AppliedVersion))]
    public Guid VersionId { get; set; }
    public virtual required AppVersionControls AppliedVersion { get; set; }
    
}