using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.Settings.Commands;

public class AddUpdateSettingCommand(AppSettings entity) : AddOrUpdateCommand<AppSettings, Guid>(entity);

internal class AddUpdateSettingCommandHandler(IServices<AppSettings, Guid> settingService, IUnitOfWork unitOfWork)
    : ICommandHandler<AddUpdateSettingCommand, AppSettings>
{
    public async Task<AppSettings> HandleAsync(AddUpdateSettingCommand command, CancellationToken cancellationToken = default)
    {
        using (await unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken))
        {
            var result = await settingService.AddOrUpdateAsync(command.Entity, cancellationToken);

            await unitOfWork.CommitTransactionAsync(cancellationToken);
            return result;
        }
    }
}