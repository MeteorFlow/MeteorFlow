using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;
using MeteorFlow.Core.Entities;

namespace MeteorFlow.Core.Settings.Queries;

public class GetAllSettings : GetAllQuery<AppSettings, Guid>;

internal class GetAllSettingsHandler(IServices<AppSettings, Guid> settingService)
    : IQueryHandler<GetAllSettings, List<AppSettings>>
{
    public Task<List<AppSettings>> HandleAsync(GetAllSettings query, CancellationToken cancellationToken = default)
    {
        return settingService.GetAsync(cancellationToken);
    }
}