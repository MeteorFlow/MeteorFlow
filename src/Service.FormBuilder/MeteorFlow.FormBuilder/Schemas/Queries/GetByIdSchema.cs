using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;
using MeteorFlow.FormBuilder.Elements.Queries;

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