using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.VersionControls.Commands;

public class AddVersionControlCommand (AppVersionControls entity) : AddCommand<AppVersionControls,Guid> (entity);

internal class AddVersionControlCommandHandler(IServices<AppVersionControls, Guid> versionControlService) 
    : ICommandHandler<AddVersionControlCommand, AppVersionControls>
{
    public Task<AppVersionControls> HandleAsync(AddVersionControlCommand command, CancellationToken cancellationToken = default)
    {
        return versionControlService.AddAsync(command.Entity, cancellationToken);
    }
}
