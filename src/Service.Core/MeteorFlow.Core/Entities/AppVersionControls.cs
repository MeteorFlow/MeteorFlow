using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Fx.Entities;

namespace MeteorFlow.Core.Entities;

public class AppVersionControls: Entity<Guid>, IVersionControl
{
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
    public int PatchVersion { get; set; }
    
    [ForeignKey(nameof(AppDefinition))]
    public Guid AppDefinitionId { get; set; }
    public virtual required AppDefinitions AppDefinition { get; set; }
}