namespace MeteorFlow.Fx.Commands;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation = default) where TCommand : ICommand<TCommandResult>;
}