using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.Definitions.Commands;

public class AddDefinitionCommand(Entities.AppDefinitions entity): AddCommand<Entities.AppDefinitions,Guid>(entity);

internal class AddDefinitionCommandHandler(IServices<Entities.AppDefinitions, Guid> definitionService) : ICommandHandler<AddDefinitionCommand, Entities.AppDefinitions>
{
    public Task<Entities.AppDefinitions> HandleAsync(AddDefinitionCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddAsync(command.Entity, cancellationToken);
        
    }
}