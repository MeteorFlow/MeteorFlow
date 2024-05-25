using MeteorFlow.Application.Queries;

namespace MeteorFlow.Application.Handlers;

public interface IQueryDispatcher
{
    Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellation = default) where TQuery : IQuery<TResult>;
}