using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.VersionControls.Commands;

public class AddUpdateVersionControlCommand(AppVersionControls entity): AddOrUpdateCommand<AppVersionControls, Guid>(entity);

internal class AddUpdateVersionControlCommandHandler(IServices<AppVersionControls, Guid> versionControlService, IUnitOfWork unitOfWork) 
    : ICommandHandler<AddUpdateVersionControlCommand, AppVersionControls>
{
    public Task<AppVersionControls> HandleAsync(AddUpdateVersionControlCommand command, CancellationToken cancellationToken = default)
    {
        return versionControlService.AddOrUpdateAsync(command.Entity, cancellationToken);
    }
}