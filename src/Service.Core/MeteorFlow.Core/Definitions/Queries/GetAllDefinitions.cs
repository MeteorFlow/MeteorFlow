using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Domain.App;

namespace MeteorFlow.Core.Definitions.Queries;

public class GetAllDefinitions : GetAllQuery<Entities.AppDefinitions, Guid>
{
    public AppDefinitionTypes Type { get; set; }
    public bool IncludeBase { get; set; }
    public bool IncludeSub { get; set; }
    public bool IncludeVersion { get; set; }
    public bool AsNoTracking { get; set; }
}

internal class GetAllDefinitionsHandler(IDefinitionRepository repository) : IQueryHandler<GetAllDefinitions, List<Entities.AppDefinitions>>
{
    public Task<List<Entities.AppDefinitions>> HandleAsync(GetAllDefinitions query, CancellationToken cancellationToken = default)
    {
        var data = repository.Get(new DefinitionQueryOptions
        {
            IncludeBase = query.IncludeBase,
            IncludeSub = query.IncludeSub,
            IncludeVersion = query.IncludeVersion,
            AsNoTracking = query.AsNoTracking
        });

        if (query.Type != AppDefinitionTypes.None)
        {
            data = data.Where(x => x.DefinitionType == query.Type);
        }

        return repository.ToListAsync(data);
    }
}