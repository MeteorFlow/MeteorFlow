using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.VersionControls.Queries;

public class GetAllVersionControls: GetAllQuery<AppVersionControls, Guid>;

internal class GetAllVersionControlsHandler(IServices<AppVersionControls, Guid> versionControlService) 
    : IQueryHandler<GetAllVersionControls, List<AppVersionControls>>
{
    public Task<List<AppVersionControls>> HandleAsync(GetAllVersionControls query, CancellationToken cancellationToken = default)
    {
        return versionControlService.GetAsync(cancellationToken);
    }
}