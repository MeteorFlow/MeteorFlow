using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Auth.Core.Commands;

public class AddElementCommand(Entities.FormElements entity): AddCommand<Entities.FormElements,Guid>(entity);

internal class AddFormElementCommandHandler(IServices<Entities.FormElements, Guid> definitionService) : ICommandHandler<AddElementCommand, Entities.FormElements>
{
    public Task<Entities.FormElements> HandleAsync(AddElementCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddAsync(command.Entity, cancellationToken);
        
    }
}