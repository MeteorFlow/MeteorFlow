using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;

namespace MeteorFlow.FormBuilder.Blocks.Commands;

public class AddBlockCommand(Entities.FormBlocks entity) : AddCommand<Entities.FormBlocks, Guid>(entity);

internal class AddFormBlockCommandHandler(IServices<Entities.FormBlocks, Guid> service)
    : ICommandHandler<AddBlockCommand, Entities.FormBlocks>
{
    public Task<Entities.FormBlocks> HandleAsync(AddBlockCommand command, CancellationToken cancellationToken = default)
    {
        return service.AddAsync(command.Entity, cancellationToken);
    }
}