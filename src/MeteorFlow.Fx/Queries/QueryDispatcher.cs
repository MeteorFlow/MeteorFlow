using Microsoft.Extensions.DependencyInjection;

namespace MeteorFlow.Fx.Queries;

internal class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    public Task<TQueryResult> Dispatch<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellation = default)
    {
        var handler = serviceProvider.GetRequiredService<IQueryHandler<IQuery<TQueryResult>, TQueryResult>>();
        return handler.HandleAsync(query, cancellation);
    }
}