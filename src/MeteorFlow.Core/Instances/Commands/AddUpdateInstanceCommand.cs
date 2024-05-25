using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.Instances.Commands;

public class AddUpdateInstanceCommand(Entities.AppInstances entity): AddOrUpdateCommand<Entities.AppInstances, Guid> (entity);

internal class AddUpdateInstanceCommandHandler(IServices<Entities.AppInstances, Guid> instanceService) : ICommandHandler<AddUpdateInstanceCommand, Entities.AppInstances>
{
    public Task<Entities.AppInstances> HandleAsync(AddUpdateInstanceCommand command, CancellationToken cancellationToken = default)
    {
        return instanceService.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}
