using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;

namespace MeteorFlow.FormBuilder.Blocks.Queries;

public class GetAllBlocks : GetAllQuery<Entities.FormBlocks, Guid>;

internal class GetAllBlocksHandler(IServices<Entities.FormBlocks, Guid> service) 
    : IQueryHandler<GetAllBlocks, List<Entities.FormBlocks>>
{
    public Task<List<Entities.FormBlocks>> HandleAsync(GetAllBlocks query, CancellationToken cancellationToken = default)
    {
        return service.GetAsync(cancellationToken);
    }
}
