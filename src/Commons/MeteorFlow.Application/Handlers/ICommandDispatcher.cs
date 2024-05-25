using MeteorFlow.Application.Commands;

namespace MeteorFlow.Application.Handlers;

public interface ICommandDispatcher
{
    Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation = default) where TCommand : ICommand<TCommandResult>;
}