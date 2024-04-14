using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.Commands;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.Core.Commands;

public class AddUpdateSettingCommand(AppSettings entity) : AddOrUpdateCommand<AppSettings, Guid>(entity);

internal class AddUpdateProductCommandHandler : ICommandHandler<AddUpdateSettingCommand, AppSettings>
{
    private readonly IServices<AppSettings, Guid> _settingService;
    private readonly IUnitOfWork _unitOfWork;

    public AddUpdateProductCommandHandler(IServices<AppSettings, Guid> settingService, IUnitOfWork unitOfWork)
    {
        _settingService = settingService;
        _unitOfWork = unitOfWork;
    }

    public async Task<AppSettings> HandleAsync(AddUpdateSettingCommand command, CancellationToken cancellationToken = default)
    {
        using (await _unitOfWork.BeginTransactionAsync(System.Data.IsolationLevel.ReadCommitted, cancellationToken))
        {
            var result = await _settingService.AddOrUpdateAsync(command.Entity, cancellationToken);

            await _unitOfWork.CommitTransactionAsync(cancellationToken);
            return result;
        }
    }
}