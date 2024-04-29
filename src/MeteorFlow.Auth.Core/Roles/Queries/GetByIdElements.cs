using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Core.Queries;

public class GetByIdElement: GetByIdQuery<Entities.FormElements,Guid>;

internal class GetByIdElementHandler(IServices<Entities.FormElements, Guid> service) 
    : IQueryHandler<GetByIdElement, Entities.FormElements>
{
    public Task<Entities.FormElements> HandleAsync(GetByIdElement query, CancellationToken cancellationToken = default)
    {
        return service.GetByIdAsync(query.Id, cancellationToken);
    }
}