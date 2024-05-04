using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Schemas.Queries;

public class GetAllSchemas : GetAllQuery<Entities.ElementSchemas, Guid>;

internal class GetAllSchemasHandler(IServices<Entities.ElementSchemas, Guid> service)
    : IQueryHandler<GetAllSchemas, List<Entities.ElementSchemas>>
{
    public Task<List<Entities.ElementSchemas>> HandleAsync(GetAllSchemas query,
        CancellationToken cancellationToken = default)
    {
        return service.GetAsync(cancellationToken);
    }
}