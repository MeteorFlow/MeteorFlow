using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Commands;

public class AddUpdateElementCommand(Entities.FormElements entity): AddOrUpdateCommand<Entities.FormElements,Guid>(entity);

internal class AddUpdateElementCommandHandler(IServices<Entities.FormElements, Guid> definitionService) : ICommandHandler<AddUpdateElementCommand, Entities.FormElements>
{
    public Task<Entities.FormElements> HandleAsync(AddUpdateElementCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}