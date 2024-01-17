using AutoMapper;
using MeteorFlow.Core.Extensions;
using MeteorFlow.Domain;
using Microsoft.EntityFrameworkCore;
using ObservationValues = MeteorFlow.Domain.ObservationValues;

namespace MeteorFlow.Core.Services.Metadata;

public class MetadataService(IMapper mapper, ICoreDbContext context) : IMetadataService
{
    private readonly IMapper _mapper = mapper;
    private readonly ICoreDbContext _context = context;


    public async ValueTask<ICollection<ObservationElements>> GetElementsAsync()
    {
        var entities = await _context.ObservationElements.Include(o => o.Unit).ToListAsync();
        return _mapper.Map<IList<ObservationElements>>(entities);
    }

    public async ValueTask<ICollection<Units>> GetUnitsAsync()
    {
        var entities = await _context.Units.ToListAsync();
        return _mapper.Map<IList<Units>>(entities);
    }

    public async ValueTask<ICollection<Stations>> GetStationsAsync()
    {
        var entities = await _context.Stations.ToListAsync();
        return _mapper.Map<IList<Stations>>(entities);
    }

    public async ValueTask<ObservationValues> GetValuesAsync(int elementId, int stationId)
    {
        var entities = await _context.ObservationValues
            .Where(v => v.ElementId == elementId && v.StationId == stationId)
            .Include(v => v.Element)
            .Include(v => v.Station)
            .ToListAsync();
        return _mapper.Map<ObservationValues>(entities);
    }

    public async ValueTask AddValuesAsync(ICollection<ObservationValues> values)
    {
        await _context.ObservationValues.AddRangeAsync(_mapper.Map<List<Entities.ObservationValues>>(values));
        await _context.SaveChangesAsync();
    }

    public async ValueTask AddElementsAsync(ICollection<ObservationElements> elements)
    {
        await _context.ObservationElements.AddRangeAsync(_mapper.Map<List<Entities.ObservationElements>>(elements));
        await _context.SaveChangesAsync();
    }

    public async ValueTask AddStationAsync(Stations stations)
    {
        await _context.Stations.AddAsync(_mapper.Map<Entities.Stations>(stations));
        await _context.SaveChangesAsync();
    }

    public async ValueTask AddUnitsAsync(ICollection<Units> units)
    {
        await _context.Units.AddRangeAsync(_mapper.Map<List<Entities.Units>>(units));
        await _context.SaveChangesAsync();
    }

    public async ValueTask UpdateValuesAsync(ICollection<ObservationValues> values)
    {
        _context.ObservationValues.UpdateRange(_mapper.Map<List<Entities.ObservationValues>>(values));
        await _context.SaveChangesAsync();
    }
}