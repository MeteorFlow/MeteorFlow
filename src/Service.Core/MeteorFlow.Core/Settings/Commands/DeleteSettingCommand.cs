using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;
using MeteorFlow.Core.Entities;

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