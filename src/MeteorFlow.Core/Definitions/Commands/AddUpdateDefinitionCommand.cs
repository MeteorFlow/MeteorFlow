using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.Definitions.Commands;

public class AddUpdateDefinitionCommand(Entities.AppDefinitions entity): AddOrUpdateCommand<Entities.AppDefinitions,Guid>(entity);

internal class AddUpdateDefinitionCommandHandler(IServices<Entities.AppDefinitions, Guid> definitionService) : ICommandHandler<AddUpdateDefinitionCommand, Entities.AppDefinitions>
{
    public Task<Entities.AppDefinitions> HandleAsync(AddUpdateDefinitionCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}