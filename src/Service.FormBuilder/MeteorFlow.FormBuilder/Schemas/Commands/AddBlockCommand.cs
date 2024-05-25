using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;

namespace MeteorFlow.FormBuilder.Schemas.Commands;

public class AddSchemaCommand(Entities.ElementSchemas entity) : AddCommand<Entities.ElementSchemas, Guid>(entity);

internal class AddElementSchemaCommandHandler(IServices<Entities.ElementSchemas, Guid> service)
    : ICommandHandler<AddSchemaCommand, Entities.ElementSchemas>
{
    public Task<Entities.ElementSchemas> HandleAsync(AddSchemaCommand command,
        CancellationToken cancellationToken = default)
    {
        return service.AddAsync(command.Entity, cancellationToken);
    }
}