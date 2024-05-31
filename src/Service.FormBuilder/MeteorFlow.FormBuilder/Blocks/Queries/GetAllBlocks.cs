using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;

namespace MeteorFlow.FormBuilder.Blocks.Queries;

public class GetAllBlocks : GetAllQuery<Entities.FormBlocks, Guid>
{
    public Guid VersionId { get; set; }
}

internal class GetAllBlocksHandler(IServices<Entities.FormBlocks, Guid> service) 
    : IQueryHandler<GetAllBlocks, List<Entities.FormBlocks>>
{
    public async Task<List<Entities.FormBlocks>> HandleAsync(GetAllBlocks query, CancellationToken cancellationToken = default)
    {
        var result = await service.GetAsync(cancellationToken);
        return result.Where(f => f.VersionId == query.VersionId).ToList();
    }
}
