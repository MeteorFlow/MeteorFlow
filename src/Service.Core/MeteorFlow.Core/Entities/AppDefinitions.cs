using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Domain.App;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Core.Entities;

public class AppDefinitions: Entity<Guid>, IEntityObject
{
    [Required, MaxLength(Utils.MaxDisplayNameLength)] 
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(Utils.MaxDescriptionLength)]
    public string Description { get; set; }  = string.Empty;
    
    [MaxLength(Utils.MaxMetadataLength)]
    public string? Icon { get; set; }
    
    [ForeignKey(nameof(BaseDefinition))]
    public Guid? BaseDefinitionId { get; set; }
    
    public Guid TenantId { get; set; }
    public AppDefinitionTypes DefinitionType { get; set; } = AppDefinitionTypes.System;
    public virtual AppDefinitions? BaseDefinition { get; set; }
    
    public virtual ICollection<AppDefinitions> SubDefinitions { get; set; } = new List<AppDefinitions>();
    public virtual ICollection<AppVersionControls> AppVersionControls { get; set; } = new List<AppVersionControls>();

}