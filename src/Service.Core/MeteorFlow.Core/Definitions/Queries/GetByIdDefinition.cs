using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;

namespace MeteorFlow.Core.Definitions.Queries;

public class GetByIdDefinition : GetByIdQuery<Entities.AppDefinitions, Guid>;

internal class GetByIdDefinitionHandler(IServices<Entities.AppDefinitions, Guid> definitionService) 
    : IQueryHandler<GetByIdDefinition, Entities.AppDefinitions>
{
    public Task<Entities.AppDefinitions> HandleAsync(GetByIdDefinition query, CancellationToken cancellationToken = default)
    {
        return definitionService.GetByIdAsync(query.Id, cancellationToken);
    }
}