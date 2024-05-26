using MeteorFlow.Application.Crud;
using MeteorFlow.Application.Queries;

namespace MeteorFlow.FormBuilder.Elements.Queries;

public class GetAllElements : GetAllQuery<Entities.FormElements, Guid>;

internal class GetAllElementsHandler(IServices<Entities.FormElements, Guid> service) 
    : IQueryHandler<GetAllElements, List<Entities.FormElements>>
{
    public Task<List<Entities.FormElements>> HandleAsync(GetAllElements query, CancellationToken cancellationToken = default)
    {
        return service.GetAsync(cancellationToken);
    }
}
