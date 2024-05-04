using System.ComponentModel.DataAnnotations;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Core.Entities;

public class AppSettings: Entity<Guid>
{
    [Required, MaxLength(Utils.MaxDisplayNameLength)] 
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(Utils.MaxDescriptionLength)]
    public string Description { get; set; }  = string.Empty;
    
    [MaxLength(Utils.MaxMetadataLength)] 
    public string Value { get; set; } = string.Empty;

    [MaxLength(255)]
    public string Type { get; set; } = String.Empty;
}