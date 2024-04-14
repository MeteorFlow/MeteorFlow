namespace MeteorFlow.Fx.Queries;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQueryResult>(IQuery<TQueryResult> query, CancellationToken cancellation = default);
}