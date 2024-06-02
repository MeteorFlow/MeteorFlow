using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;
using MeteorFlow.FormBuilder.Repositories;

namespace MeteorFlow.FormBuilder.Blocks.Queries;

public class GetAllBlocks : GetAllQuery<Entities.FormBlocks, Guid>
{
    public Guid VersionId { get; set; }
}

internal class GetAllBlocksHandler(IBlockRepository repository) 
    : IQueryHandler<GetAllBlocks, List<Entities.FormBlocks>>
{
    public Task<List<Entities.FormBlocks>> HandleAsync(GetAllBlocks query, CancellationToken cancellationToken = default)
    {
        var data = repository.Get(new BlockQueryOptions()
        {
            VersionId = query.VersionId,
            IncludeSchema = true,
            IncludeElement = true,
            AsNoTracking = false,
        });
        return repository.ToListAsync(data);
    }
}
