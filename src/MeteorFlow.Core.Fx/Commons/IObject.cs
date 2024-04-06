using System.ComponentModel.DataAnnotations;

namespace MeteorFlow.Core.Fx.Commons;

public interface IObject
{
    [Required, MaxLength(Int16.MaxValue)]
    public string Name { get; set; }

    [MaxLength(Int32.MaxValue)] 
    public string Description { get; set; }

    [MaxLength(Int32.MaxValue)]
    public string Icon { get; set; }
}