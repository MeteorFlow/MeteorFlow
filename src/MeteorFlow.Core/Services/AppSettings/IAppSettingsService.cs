namespace MeteorFlow.Core.Services.AppSettings;

public interface IAppSettingsService
{
    ValueTask<ICollection<Domain.AppSettings>> GetAllAsync();
    ValueTask UpdateAsync(ICollection<Domain.AppSettings> settings);
    ValueTask<Domain.AppSettings> AddAsync(Domain.AppSettings setting);
    ValueTask Remove(string id);
    ValueTask<Domain.AppSettings?> GetById(string referenceKey);
}