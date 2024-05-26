using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;

namespace MeteorFlow.FormBuilder.Schemas.Commands;

public class AddUpdateSchemaCommand(Entities.ElementSchemas entity)
    : AddOrUpdateCommand<Entities.ElementSchemas, Guid>(entity);

internal class AddUpdateSchemaCommandHandler(IServices<Entities.ElementSchemas, Guid> service)
    : ICommandHandler<AddUpdateSchemaCommand, Entities.ElementSchemas>
{
    public Task<Entities.ElementSchemas> HandleAsync(AddUpdateSchemaCommand command,
        CancellationToken cancellationToken = default)
    {
        return service.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}