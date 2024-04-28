using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Core.Commands;

public class DeleteElementCommand(Entities.FormElements entity): DeleteCommand<Entities.FormElements,Guid>(entity);

internal class DeleteElementCommandHandler(IServices<Entities.FormElements, Guid> definitionService) : ICommandHandler<DeleteElementCommand, Entities.FormElements>
{
    public Task<Entities.FormElements> HandleAsync(DeleteElementCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.DeleteAsync(command.Entity, cancellationToken);
    }
}