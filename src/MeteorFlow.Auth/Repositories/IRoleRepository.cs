using MeteorFlow.Auth.Entities;
using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Fx.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Auth.Repositories;

public class RoleQueryOptions
{
    public bool IncludeClaims { get; set; }
    public bool IncludeUserRoles { get; set; }
    public bool IncludeUsers { get; set; }
    public bool AsNoTracking { get; set; }
    
    public Guid? ById { get; set; }
    
    public string ByNormalizedName { get; set; }
}

public interface IRoleRepository : IRepository<Role, Guid>
{
    IQueryable<Role> Get(RoleQueryOptions queryOptions);
}