using MeteorFlow.Domain;
using ObservationValues = MeteorFlow.Domain.ObservationValues;

namespace MeteorFlow.Core.Services.Metadata;

public interface IMetadataService
{
    ValueTask<ICollection<ObservationElements>> GetElementsAsync();
    ValueTask<ICollection<Units>> GetUnitsAsync();
    ValueTask<ObservationValues> GetValuesAsync(int elementId, int stationId);
    ValueTask AddValuesAsync(ICollection<ObservationValues> values);
    ValueTask AddElementsAsync(ICollection<ObservationElements> elements);
    ValueTask AddUnitsAsync(ICollection<Units> units);
    ValueTask UpdateValuesAsync(ICollection<ObservationValues> values);
}