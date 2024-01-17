using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Domain;

public class ObservationElements: BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Abbreviation { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ObservationElements Parent { get; set; }
    public Units Units { get; set; }
    public double? Scale { get; set; }
    public double? MaxValue { get; set; }
    public double? MinValue { get; set; }
}