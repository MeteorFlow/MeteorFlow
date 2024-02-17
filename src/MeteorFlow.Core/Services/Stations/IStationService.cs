namespace MeteorFlow.Core.Services.Stations;

public interface IStationService
{
    ValueTask<Domain.Tenants.Stations> AddStationAsync(Domain.Tenants.Stations stations);
    ValueTask UpdateStationAsync(Domain.Tenants.Stations stations);
    ValueTask<ICollection<Domain.Tenants.Stations>> GetStationsAsync();
    ValueTask<Domain.Tenants.Stations?> GetStationByIdAsync(int stationId);
    ValueTask RemoveStationAsync(int stationId);
}