using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Blocks.Commands;

public class AddUpdateBlockCommand(Entities.FormBlocks entity): AddOrUpdateCommand<Entities.FormBlocks,Guid>(entity);

internal class AddUpdateBlockCommandHandler(IServices<Entities.FormBlocks, Guid> definitionService) : ICommandHandler<AddUpdateBlockCommand, Entities.FormBlocks>
{
    public Task<Entities.FormBlocks> HandleAsync(AddUpdateBlockCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}