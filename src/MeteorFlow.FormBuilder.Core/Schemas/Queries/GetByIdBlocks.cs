using MeteorFlow.FormBuilder.Core.Queries;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Core.Schemas.Queries;

public class GetByIdSchema: GetByIdQuery<Entities.ElementSchemas,Guid>;

internal class GetByIdElementHandler(IServices<Entities.ElementSchemas, Guid> service) 
    : IQueryHandler<GetByIdElement, Entities.ElementSchemas>
{
    public Task<Entities.ElementSchemas> HandleAsync(GetByIdElement query, CancellationToken cancellationToken = default)
    {
        return service.GetByIdAsync(query.Id, cancellationToken);
    }
}