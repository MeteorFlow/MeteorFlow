using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.VersionControls.Commands;

public class DeleteVersionControlCommand(AppVersionControls entity): DeleteCommand<AppVersionControls, Guid>(entity);

internal class DeleteVersionControlCommandHandler(IServices<AppVersionControls, Guid> versionControlService) 
    : ICommandHandler<DeleteVersionControlCommand, AppVersionControls>
{
    public Task<AppVersionControls> HandleAsync(DeleteVersionControlCommand command, CancellationToken cancellationToken = default)
    {
        return versionControlService.DeleteAsync(command.Entity, cancellationToken);
    }
}