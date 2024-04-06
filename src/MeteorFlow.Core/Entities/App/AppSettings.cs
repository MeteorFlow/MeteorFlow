using System.ComponentModel.DataAnnotations;
using MeteorFlow.Core.Fx.Commons;
using MeteorFlow.Core.Fx.Models;

namespace MeteorFlow.Core.Entities.App;

public class AppSettings: Base<Guid>, IObject
{
    public string Name { get; set; } = String.Empty;

    [MaxLength(Int32.MaxValue)]
    public string Value { get; set; } = String.Empty;

    public string Description { get; set; } = String.Empty;

    public string? Icon { get; set; }

    [MaxLength(255)]
    public string Type { get; set; } = String.Empty;
}