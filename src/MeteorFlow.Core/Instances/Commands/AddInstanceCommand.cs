using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.Instances.Commands;

public class AddInstanceCommand(Entities.AppInstances entity): AddCommand<Entities.AppInstances,Guid>(entity);

internal class AddInstanceCommandHandler(IServices<Entities.AppInstances, Guid> instanceService) 
    : ICommandHandler<AddInstanceCommand, Entities.AppInstances>
{
    public Task<Entities.AppInstances> HandleAsync(AddInstanceCommand command, CancellationToken cancellationToken = default)
    {
        return instanceService.AddAsync(command.Entity, cancellationToken);
        
    }
}