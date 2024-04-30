using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;
using MeteorFlow.Fx.Queries;

namespace MeteorFlow.Auth.Roles.Queries;

public class GetRolesQuery : IQuery<List<Role>>
{
    public bool IncludeClaims { get; set; }
    public bool IncludeUserRoles { get; set; }
    public bool AsNoTracking { get; set; }
}

public class GetRolesQueryHandler(IRoleRepository roleRepository) : IQueryHandler<GetRolesQuery, List<Role>>
{
    public Task<List<Role>> HandleAsync(GetRolesQuery query, CancellationToken cancellationToken = default)
    {
        var role = roleRepository.Get(new RoleQueryOptions
        {
            IncludeClaims = query.IncludeClaims,
            IncludeUserRoles = query.IncludeUserRoles,
            AsNoTracking = query.AsNoTracking,
        });

        return roleRepository.ToListAsync(role);
    }
}