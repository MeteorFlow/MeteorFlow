namespace MeteorFlow.Core.Services.AppSettings;

public interface IAppSettingsService
{
    ValueTask<ICollection<Domain.App.AppSettings>> GetAllAsync();
    ValueTask UpdateAsync(ICollection<Domain.App.AppSettings> settings);
    ValueTask<Domain.App.AppSettings> AddAsync(Domain.App.AppSettings setting);
    ValueTask Remove(string id);
    ValueTask<Domain.App.AppSettings?> GetById(string referenceKey);
}