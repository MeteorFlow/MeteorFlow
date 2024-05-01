using MeteorFlow.FormBuilder.Core.Commands;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Core.Blocks.Commands;

public class DeleteBlockCommand(Entities.FormBlocks entity): DeleteCommand<Entities.FormBlocks,Guid>(entity);

internal class DeleteBlockCommandHandler(IServices<Entities.FormBlocks, Guid> definitionService) : ICommandHandler<DeleteBlockCommand, Entities.FormBlocks>
{
    public Task<Entities.FormBlocks> HandleAsync(DeleteBlockCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.DeleteAsync(command.Entity, cancellationToken);
    }
}