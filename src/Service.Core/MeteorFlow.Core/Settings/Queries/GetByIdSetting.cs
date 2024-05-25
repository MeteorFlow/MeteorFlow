using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;
using MeteorFlow.Core.Entities;

namespace MeteorFlow.Core.Settings.Queries;

public class GetByIdSetting: GetByIdQuery<AppSettings, Guid>;

internal class GetIdSettingHandler(IServices<AppSettings, Guid> settingService)
    : IQueryHandler<GetByIdSetting, AppSettings>
{
    public Task<AppSettings> HandleAsync(GetByIdSetting query, CancellationToken cancellationToken = default)
    {
        return settingService.GetByIdAsync(query.Id, cancellationToken);
    }
} 