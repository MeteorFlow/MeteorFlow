using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.Settings.Commands; 
public class DeleteSettingCommand(AppSettings entity) : DeleteCommand<AppSettings, Guid>(entity);

internal class DeleteSettingCommandHandler(IServices<AppSettings, Guid> settingService)
    : ICommandHandler<DeleteSettingCommand, AppSettings>
{
    public Task<AppSettings> HandleAsync(DeleteSettingCommand command, CancellationToken cancellationToken = default)
    {
        return settingService.DeleteAsync(command.Entity, cancellationToken);
    }
}