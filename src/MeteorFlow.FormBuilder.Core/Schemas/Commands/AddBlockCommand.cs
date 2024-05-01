using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Core.Schemas.Commands;

public class AddSchemaCommand(Entities.ElementSchemas entity): AddCommand<Entities.ElementSchemas,Guid>(entity);

internal class AddElementSchemaCommandHandler(IServices<Entities.ElementSchemas, Guid> definitionService) : ICommandHandler<AddSchemaCommand, Entities.ElementSchemas>
{
    public Task<Entities.ElementSchemas> HandleAsync(AddSchemaCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddAsync(command.Entity, cancellationToken);
        
    }
}