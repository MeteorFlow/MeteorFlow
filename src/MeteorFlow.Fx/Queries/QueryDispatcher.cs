using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Fx.Queries;

internal class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    public Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellation = default) where TQuery : IQuery<TResult>
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
        return handler.HandleAsync(query, cancellation);
    }
}