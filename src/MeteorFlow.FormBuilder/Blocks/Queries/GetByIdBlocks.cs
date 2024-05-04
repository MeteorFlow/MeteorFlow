using MeteorFlow.FormBuilder.Queries;
using MeteorFlow.Fx.Queries;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Blocks.Queries;

public class GetByIdBlock: GetByIdQuery<Entities.FormBlocks,Guid>;

internal class GetByIdElementHandler(IServices<Entities.FormBlocks, Guid> service) 
    : IQueryHandler<GetByIdElement, Entities.FormBlocks>
{
    public Task<Entities.FormBlocks> HandleAsync(GetByIdElement query, CancellationToken cancellationToken = default)
    {
        return service.GetByIdAsync(query.Id, cancellationToken);
    }
}