using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.Instances.Commands;

public class DeleteInstanceCommand(Entities.AppInstances entity): DeleteCommand<Entities.AppInstances, Guid>(entity);

internal class DeleteInstanceCommandHandler(IServices<Entities.AppInstances, Guid> instanceService) : ICommandHandler<DeleteInstanceCommand, Entities.AppInstances>
{
    public Task<Entities.AppInstances> HandleAsync(DeleteInstanceCommand command, CancellationToken cancellationToken = default)
    {
        return instanceService.DeleteAsync(command.Entity, cancellationToken);
    }
}