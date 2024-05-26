using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;
using MeteorFlow.Core.Entities;

namespace MeteorFlow.Core.VersionControls.Commands;

public class AddUpdateVersionControlCommand(AppVersionControls entity): AddOrUpdateCommand<AppVersionControls, Guid>(entity);

internal class AddUpdateVersionControlCommandHandler(IServices<AppVersionControls, Guid> versionControlService) 
    : ICommandHandler<AddUpdateVersionControlCommand, AppVersionControls>
{
    public Task<AppVersionControls> HandleAsync(AddUpdateVersionControlCommand command, CancellationToken cancellationToken = default)
    {
        return versionControlService.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}