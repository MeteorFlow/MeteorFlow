using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Schemas.Commands;

public class DeleteSchemaCommand(Entities.ElementSchemas entity) : DeleteCommand<Entities.ElementSchemas, Guid>(entity);

internal class DeleteSchemaCommandHandler(IServices<Entities.ElementSchemas, Guid> service)
    : ICommandHandler<DeleteSchemaCommand, Entities.ElementSchemas>
{
    public Task<Entities.ElementSchemas> HandleAsync(DeleteSchemaCommand command,
        CancellationToken cancellationToken = default)
    {
        return service.DeleteAsync(command.Entity, cancellationToken);
    }
}