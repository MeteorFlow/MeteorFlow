using System.ComponentModel.DataAnnotations.Schema;
using MeteorFlow.Core.Fx.Commons;
using MeteorFlow.Core.Fx.Models;

namespace MeteorFlow.Core.Entities.App;

public class AppVersionControls: Base<Guid>, IVersionControl
{
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
    public int PatchVersion { get; set; }
    public DateTimeOffset Timestamp { get; set; }
    
    [ForeignKey(nameof(AppDefinition))]
    public Guid AppDefinitionId { get; set; }
    public virtual required AppDefinitions AppDefinition { get; set; }
    
}