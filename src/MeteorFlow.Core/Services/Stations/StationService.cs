using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MeteorFlow.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Core.Services.Stations;

public class StationService(IMapper mapper, ICoreDbContext context) : IStationService
{
    public async ValueTask<Domain.Tenants.Stations> AddStationAsync(Domain.Tenants.Stations stations)
    {
        if (string.IsNullOrWhiteSpace(stations.Name))
        {
            throw new ValidationException($"Invalid: {nameof(Domain.Tenants.Stations.Name)} should not be empty.");
        }

        var entity = context.Stations.Add(mapper.Map<Entities.Tenants.Stations>(stations)).Entity;
        await context.SaveChangesAsync();
        return mapper.Map<Domain.Tenants.Stations>(entity);
    }

    public async ValueTask UpdateStationAsync(Domain.Tenants.Stations stations)
    {
        var entity = await context.Stations.FirstOrDefaultAsync(s => s.Id == stations.Id);
        if (entity is null)
        {
            throw new ValidationException($"Invalid: {stations.Id} is not existed.");
        }
        context.Stations.Entry(entity).CurrentValues.SetValues(mapper.Map<Entities.Tenants.Stations>(stations));
        await context.SaveChangesAsync();
    }

    public async ValueTask<ICollection<Domain.Tenants.Stations>> GetStationsAsync()
    {
        var entities = await context.Stations.AsNoTracking().ToListAsync();
        return mapper.Map<IList<Domain.Tenants.Stations>>(entities);
    }

    public async ValueTask<Domain.Tenants.Stations?> GetStationByIdAsync(int stationId)
    {
        var entity = await context.Stations.AsNoTracking().FirstOrDefaultAsync(s => s.Id == stationId);
        return mapper.Map<Domain.Tenants.Stations>(entity);
    }

    public async ValueTask RemoveStationAsync(int stationId)
    {
        var entity = await context.Stations.FirstOrDefaultAsync(s => s.Id == stationId);
        if (entity is null)
        {
            throw new ValidationException($"Invalid: {stationId} is not existed.");
        }
        
        context.Stations.Remove(entity);
        await context.SaveChangesAsync();
    }
}