using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;
using MeteorFlow.Core.Entities;

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