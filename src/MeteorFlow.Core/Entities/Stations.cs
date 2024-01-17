using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteorFlow.Core.Entities;

public class Stations
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [MaxLength(255)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(Int32.MaxValue)]
    public string Description { get; set; } = string.Empty;
    
    [MaxLength(255)]
    public string Location { get; set; } = string.Empty;
    
    public virtual ICollection<Profiles> Profiles { get; set; }
}