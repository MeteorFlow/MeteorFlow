using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Auth.Core.Queries;

public class GetAllElements : GetAllQuery<Entities.FormElements, Guid>;

internal class GetAllElementsHandler(IServices<Entities.FormElements, Guid> service) 
    : IQueryHandler<GetAllElements, List<Entities.FormElements>>
{
    public Task<List<Entities.FormElements>> HandleAsync(GetAllElements query, CancellationToken cancellationToken = default)
    {
        return service.GetAsync(cancellationToken);
    }
}
