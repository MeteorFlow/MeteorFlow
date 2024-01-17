using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Domain;

public class Units: BaseEntity<int>
{
    public string Name { get; set; } = string.Empty;
    public string Symbol { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public double ConversionFactor { get; set; } = 1;
}