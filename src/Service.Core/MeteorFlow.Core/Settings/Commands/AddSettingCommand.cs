using MeteorFlow.Application.Commands;
using MeteorFlow.Application.Crud;
using MeteorFlow.Core.Entities;

namespace MeteorFlow.Core.Settings.Commands;

public class AddSettingCommand(AppSettings entity) : AddCommand<AppSettings, Guid>(entity);

internal class AddSettingCommandHandler(IServices<AppSettings, Guid> settingService) 
    : ICommandHandler<AddSettingCommand, AppSettings>
{
    public Task<AppSettings> HandleAsync(AddSettingCommand command, CancellationToken cancellationToken = default)
    {
        return settingService.AddAsync(command.Entity, cancellationToken);
    }
}