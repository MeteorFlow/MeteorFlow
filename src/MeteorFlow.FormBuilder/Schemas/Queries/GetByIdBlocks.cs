using MeteorFlow.FormBuilder.Queries;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Schemas.Queries;

public class GetByIdSchema : GetByIdQuery<Entities.ElementSchemas, Guid>;

internal class GetByIdElementHandler(IServices<Entities.ElementSchemas, Guid> service)
    : IQueryHandler<GetByIdElement, Entities.ElementSchemas>
{
    public Task<Entities.ElementSchemas> HandleAsync(GetByIdElement query,
        CancellationToken cancellationToken = default)
    {
        return service.GetByIdAsync(query.Id, cancellationToken);
    }
}