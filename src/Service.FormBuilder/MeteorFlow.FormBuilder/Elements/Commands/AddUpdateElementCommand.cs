using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;

namespace MeteorFlow.FormBuilder.Elements.Commands;

public class AddUpdateElementCommand(Entities.FormElements entity): AddOrUpdateCommand<Entities.FormElements,Guid>(entity);

internal class AddUpdateElementCommandHandler(IServices<Entities.FormElements, Guid> definitionService) : ICommandHandler<AddUpdateElementCommand, Entities.FormElements>
{
    public Task<Entities.FormElements> HandleAsync(AddUpdateElementCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}