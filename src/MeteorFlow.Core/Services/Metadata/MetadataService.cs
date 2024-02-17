using AutoMapper;
using MeteorFlow.Core.Extensions;
using MeteorFlow.Domain;
using Microsoft.EntityFrameworkCore;
using ObservationValues = MeteorFlow.Domain.ObservationValues;

namespace MeteorFlow.Core.Services.Metadata;

public class MetadataService(IMapper mapper, ICoreDbContext context) : IMetadataService
{
    public async ValueTask<ICollection<ObservationElements>> GetElementsAsync()
    {
        var entities = await context.ObservationElements.AsNoTracking().Include(o => o.Unit).ToListAsync();
        return mapper.Map<IList<ObservationElements>>(entities);
    }

    public async ValueTask<ICollection<Units>> GetUnitsAsync()
    {
        var entities = await context.Units.AsNoTracking().ToListAsync();
        return mapper.Map<IList<Units>>(entities);
    }
    

    public async ValueTask<ObservationValues> GetValuesAsync(int elementId, int stationId)
    {
        var entities = await context.ObservationValues
            .AsNoTracking()
            .Where(v => v.ElementId == elementId && v.StationId == stationId)
            .Include(v => v.Element)
            .Include(v => v.Station)
            .ToListAsync();
        return mapper.Map<ObservationValues>(entities);
    }

    public async ValueTask AddValuesAsync(ICollection<ObservationValues> values)
    {
        await context.ObservationValues.AddRangeAsync(mapper.Map<List<Entities.ObservationValues>>(values));
        await context.SaveChangesAsync();
    }

    public async ValueTask AddElementsAsync(ICollection<ObservationElements> elements)
    {
        await context.ObservationElements.AddRangeAsync(mapper.Map<List<Entities.ObservationElements>>(elements));
        await context.SaveChangesAsync();
    }
    

    public async ValueTask AddUnitsAsync(ICollection<Units> units)
    {
        await context.Units.AddRangeAsync(mapper.Map<List<Entities.Units>>(units));
        await context.SaveChangesAsync();
    }

    public async ValueTask UpdateValuesAsync(ICollection<ObservationValues> values)
    {
        context.ObservationValues.UpdateRange(mapper.Map<List<Entities.ObservationValues>>(values));
        await context.SaveChangesAsync();
    }
}