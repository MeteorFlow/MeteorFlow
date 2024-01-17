using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeteorFlow.Core.Entities;

public class ObservationElements
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    [ForeignKey("Parent")]
    public int ParentId { get; set; }
    public virtual ObservationElements Parent { get; set; }
    
    [ForeignKey("Unit")]
    public int UnitId { get; set; }
    public virtual Units Unit { get; set; }
    public double Scale { get; set; }
    public double MaxValue { get; set; }
    public double MinValue { get; set; }
}