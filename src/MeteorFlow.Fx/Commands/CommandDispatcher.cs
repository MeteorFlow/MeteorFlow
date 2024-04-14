using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Fx.Commands;

internal class CommandDispatcher<TCommand, TCommandResult>(IServiceProvider serviceProvider)
    : ICommandDispatcher<TCommand, TCommandResult> where TCommand : ICommand<TCommandResult>
{
    public Task<TCommandResult> Dispatch(TCommand command, CancellationToken cancellation)
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
        return handler.HandleAsync(command, cancellation);
    }
}