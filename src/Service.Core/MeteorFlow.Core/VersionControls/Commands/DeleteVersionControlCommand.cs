using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;
using MeteorFlow.Core.Entities;

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