using MeteorFlow.Application.Queries;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;

namespace MeteorFlow.Auth.Roles.Queries;

public class GetRoleQuery : IQuery<Role>
{
    public Guid Id { get; set; }
    public bool IncludeClaims { get; set; }
    public bool IncludeUserRoles { get; set; }
    public bool IncludeUsers { get; set; }
    public bool AsNoTracking { get; set; }
}

public class GetRoleQueryHandler(IRoleRepository roleRepository) : IQueryHandler<GetRoleQuery, Role>
{
    public Task<Role> HandleAsync(GetRoleQuery query, CancellationToken cancellationToken = default)
    {
        var db = roleRepository.Get(new RoleQueryOptions
        {
            IncludeClaims = query.IncludeClaims,
            IncludeUserRoles = query.IncludeUserRoles,
            IncludeUsers = query.IncludeUsers,
            AsNoTracking = query.AsNoTracking,
        });

        return roleRepository.FirstOrDefaultAsync(db.Where(x => x.Id == query.Id));
    }
}
