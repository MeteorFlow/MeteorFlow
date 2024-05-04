namespace MeteorFlow.Fx.Queries;

public interface IQueryDispatcher
{
    Task<TResult> Dispatch<TQuery, TResult>(TQuery query, CancellationToken cancellation = default) where TQuery : IQuery<TResult>;
}