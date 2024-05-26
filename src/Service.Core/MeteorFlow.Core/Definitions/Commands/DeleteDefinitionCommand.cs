using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;

namespace MeteorFlow.Core.Definitions.Commands;

public class DeleteDefinitionCommand(Entities.AppDefinitions entity): DeleteCommand<Entities.AppDefinitions,Guid>(entity);

internal class DeleteDefinitionCommandHandler(IServices<Entities.AppDefinitions, Guid> definitionService) : ICommandHandler<DeleteDefinitionCommand, Entities.AppDefinitions>
{
    public Task<Entities.AppDefinitions> HandleAsync(DeleteDefinitionCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.DeleteAsync(command.Entity, cancellationToken);
    }
}