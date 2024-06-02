using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;
using MeteorFlow.Infrastructure.Identity;

namespace MeteorFlow.Core.Definitions.Commands;

public class AddUpdateDefinitionCommand(Entities.AppDefinitions entity): AddOrUpdateCommand<Entities.AppDefinitions,Guid>(entity);

internal class AddUpdateDefinitionCommandHandler(IServices<Entities.AppDefinitions, Guid> definitionService, ICurrentUser user) : ICommandHandler<AddUpdateDefinitionCommand, Entities.AppDefinitions>
{
    public Task<Entities.AppDefinitions> HandleAsync(AddUpdateDefinitionCommand command, CancellationToken cancellationToken = default)
    {
        command.Entity.TenantId = user.UserId;
        return definitionService.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}