using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Core.Blocks.Commands;

public class AddBlockCommand(Entities.FormBlocks entity): AddCommand<Entities.FormBlocks,Guid>(entity);

internal class AddFormBlockCommandHandler(IServices<Entities.FormBlocks, Guid> definitionService) : ICommandHandler<AddBlockCommand, Entities.FormBlocks>
{
    public Task<Entities.FormBlocks> HandleAsync(AddBlockCommand command, CancellationToken cancellationToken = default)
    {
        return definitionService.AddAsync(command.Entity, cancellationToken);
        
    }
}