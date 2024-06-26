using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;

namespace MeteorFlow.Core.Instances.Queries;

public class GetAllInstances : GetAllQuery<Entities.AppInstances, Guid>;

internal class GetAllInstancesHandler(IServices<Entities.AppInstances, Guid> instanceService) 
    : IQueryHandler<GetAllInstances, List<Entities.AppInstances>>
{
    public Task<List<Entities.AppInstances>> HandleAsync(GetAllInstances query, CancellationToken cancellationToken = default)
    {
        return instanceService.GetAsync(cancellationToken);
    }
}
