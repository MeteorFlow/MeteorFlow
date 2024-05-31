
namespace MeteorFlow.Core.Repositories;

public class DefinitionQueryOptions
{
    public bool IncludeBase { get; set; }
    public bool IncludeSub { get; set; }
    public bool IncludeVersion { get; set; }
    public bool AsNoTracking { get; set; }
}
public interface IDefinitionRepository : ICoreRepository<Entities.AppDefinitions>
{
    IQueryable<Entities.AppDefinitions> Get(DefinitionQueryOptions queryOptions);
}