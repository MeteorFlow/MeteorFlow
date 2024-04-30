using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;
using MeteorFlow.Auth.Roles.Queries;
using MeteorFlow.Fx.Queries;

namespace MeteorFlow.Auth.Users.Queries;

public class GetUsersQuery : IQuery<List<Role>>
{
    public bool IncludeClaims { get; set; }
    public bool IncludeUserRoles { get; set; }
    public bool AsNoTracking { get; set; }
}

public class GetRolesQueryHandler(IRoleRepository userRepository) : IQueryHandler<GetRolesQuery, List<Role>>
{
    public Task<List<Role>> HandleAsync(GetRolesQuery query, CancellationToken cancellationToken = default)
    {
        var role = userRepository.Get(new RoleQueryOptions
        {
            IncludeClaims = query.IncludeClaims,
            IncludeUserRoles = query.IncludeUserRoles,
            AsNoTracking = query.AsNoTracking,
        });

        return userRepository.ToListAsync(role);
    }
}