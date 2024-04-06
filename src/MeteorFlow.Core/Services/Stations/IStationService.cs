namespace MeteorFlow.Core.Services.Stations;

public interface IStationService
{
    ValueTask<Domain.Tenants.Tenants> AddStationAsync(Domain.Tenants.Tenants tenants);
    ValueTask UpdateStationAsync(Domain.Tenants.Tenants tenants);
    ValueTask<ICollection<Domain.Tenants.Tenants>> GetStationsAsync();
    ValueTask<Domain.Tenants.Tenants?> GetStationByIdAsync(int stationId);
    ValueTask RemoveStationAsync(int stationId);
}