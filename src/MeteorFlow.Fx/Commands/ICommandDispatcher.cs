namespace MeteorFlow.Fx.Commands;

public interface ICommandDispatcher<in TCommand, TCommandResult>: ICommand<TCommandResult>
{
    Task<TCommandResult> Dispatch(TCommand command, CancellationToken cancellation);
}