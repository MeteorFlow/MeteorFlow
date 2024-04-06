using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MeteorFlow.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Core.Services.Stations;

public class StationService(IMapper mapper, ICoreDbContext context) : IStationService
{
    public async ValueTask<Domain.Tenants.Tenants> AddStationAsync(Domain.Tenants.Tenants tenants)
    {
        if (string.IsNullOrWhiteSpace(tenants.Name))
        {
            throw new ValidationException($"Invalid: {nameof(Domain.Tenants.Tenants.Name)} should not be empty.");
        }

        var entity = context.Tenants.Add(mapper.Map<Entities.Department>(tenants)).Entity;
        await context.SaveChangesAsync();
        return mapper.Map<Domain.Tenants.Tenants>(entity);
    }

    public async ValueTask UpdateStationAsync(Domain.Tenants.Tenants tenants)
    {
        var entity = await context.Tenants.FirstOrDefaultAsync(s => s.Id == tenants.Id);
        if (entity is null)
        {
            throw new ValidationException($"Invalid: {tenants.Id} is not existed.");
        }
        context.Tenants.Entry(entity).CurrentValues.SetValues(mapper.Map<Entities.Department>(tenants));
        await context.SaveChangesAsync();
    }

    public async ValueTask<ICollection<Domain.Tenants.Tenants>> GetStationsAsync()
    {
        var entities = await context.Tenants.AsNoTracking().ToListAsync();
        return mapper.Map<IList<Domain.Tenants.Tenants>>(entities);
    }

    public async ValueTask<Domain.Tenants.Tenants?> GetStationByIdAsync(int stationId)
    {
        var entity = await context.Tenants.AsNoTracking().FirstOrDefaultAsync(s => s.Id == stationId);
        return mapper.Map<Domain.Tenants.Tenants>(entity);
    }

    public async ValueTask RemoveStationAsync(int stationId)
    {
        var entity = await context.Tenants.FirstOrDefaultAsync(s => s.Id == stationId);
        if (entity is null)
        {
            throw new ValidationException($"Invalid: {stationId} is not existed.");
        }
        
        context.Tenants.Remove(entity);
        await context.SaveChangesAsync();
    }
}