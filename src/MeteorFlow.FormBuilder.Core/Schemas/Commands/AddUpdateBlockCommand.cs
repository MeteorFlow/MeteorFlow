using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Core.Schemas.Commands;

public class AddUpdateSchemaCommand(Entities.ElementSchemas entity): AddOrUpdateCommand<Entities.ElementSchemas,Guid>(entity);

internal class AddUpdateSchemaCommandHandler(IServices<Entities.ElementSchemas, Guid> definitionService) : ICommandHandler<AddUpdateSchemaCommand, Entities.ElementSchemas>
{
    public Task<Entities.ElementSchemas> HandleAsync(AddUpdateSchemaCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}