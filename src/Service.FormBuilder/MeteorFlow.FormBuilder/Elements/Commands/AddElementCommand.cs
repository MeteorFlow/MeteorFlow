using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;

namespace MeteorFlow.FormBuilder.Elements.Commands;

public class AddElementCommand(Entities.FormElements entity): AddCommand<Entities.FormElements,Guid>(entity);

internal class AddFormElementCommandHandler(IServices<Entities.FormElements, Guid> definitionService) : ICommandHandler<AddElementCommand, Entities.FormElements>
{
    public Task<Entities.FormElements> HandleAsync(AddElementCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddAsync(command.Entity, cancellationToken);
        
    }
}