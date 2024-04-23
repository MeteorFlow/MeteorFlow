using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.VersionControls.Queries;

public class GetByIdVersionControl: GetByIdQuery<AppVersionControls, Guid>;

internal class GetByIdVersionControlHandler(IServices<AppVersionControls, Guid> versionControlService) 
    : IQueryHandler<GetByIdVersionControl, AppVersionControls>
{
    public Task<AppVersionControls> HandleAsync(GetByIdVersionControl query, CancellationToken cancellationToken = default)
    {
        return versionControlService.GetByIdAsync(query.Id, cancellationToken);
    }
}