using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;

namespace MeteorFlow.Core.Definitions.Queries;

public class GetAllDefinitions: GetAllQuery<Entities.AppDefinitions, Guid>;

internal class GetAllDefinitionsHandler(IServices<Entities.AppDefinitions, Guid> definitionService) : IQueryHandler<GetAllDefinitions, List<Entities.AppDefinitions>>
{
    public Task<List<Entities.AppDefinitions>> HandleAsync(GetAllDefinitions query, CancellationToken cancellationToken = default)
    {
        return definitionService.GetAsync(cancellationToken);
    }
}