using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Core.Schemas.Commands;

public class DeleteSchemaCommand(Entities.ElementSchemas entity): DeleteCommand<Entities.ElementSchemas,Guid>(entity);

internal class DeleteSchemaCommandHandler(IServices<Entities.ElementSchemas, Guid> definitionService) : ICommandHandler<DeleteSchemaCommand, Entities.ElementSchemas>
{
    public Task<Entities.ElementSchemas> HandleAsync(DeleteSchemaCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.DeleteAsync(command.Entity, cancellationToken);
    }
}