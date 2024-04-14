namespace MeteorFlow.Fx.Commands;

public interface ICommandHandler<in TCommand, TCommandResult>
    where TCommand : ICommand<TCommandResult>
{
    Task<TCommandResult> HandleAsync(TCommand command, CancellationToken cancellationToken = default);
}
