
using MeteorFlow.FormBuilder.Entities;

namespace MeteorFlow.FormBuilder.Repositories;

public class BlockQueryOptions
{
    public Guid VersionId { get; set; }
    public bool AsNoTracking { get; set; }
    public bool IncludeElement { get; set; }
    public bool IncludeSchema { get; set; }
}

public interface IBlockRepository : IFormRepository<FormBlocks>
{
    IQueryable<FormBlocks> Get(BlockQueryOptions queryQueryOptions, CancellationToken cancellationToken = default);
}