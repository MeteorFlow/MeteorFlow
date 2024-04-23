using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Fx.Commands;

internal class CommandDispatcher(IServiceProvider serviceProvider): ICommandDispatcher
{
    public Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellation) where TCommand : ICommand<TCommandResult>
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
        return handler.HandleAsync(command, cancellation);
    }
}