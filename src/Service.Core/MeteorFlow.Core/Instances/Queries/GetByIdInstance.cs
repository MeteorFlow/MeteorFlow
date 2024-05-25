using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;

namespace MeteorFlow.Core.Instances.Queries;

public class GetByIdInstance: GetByIdQuery<Entities.AppInstances,Guid>;

internal class GetByIdInstanceHandler(IServices<Entities.AppInstances, Guid> instanceService) 
    : IQueryHandler<GetByIdInstance, Entities.AppInstances>
{
    public Task<Entities.AppInstances> HandleAsync(GetByIdInstance query, CancellationToken cancellationToken = default)
    {
        return instanceService.GetByIdAsync(query.Id, cancellationToken);
    }
}