using MeteorFlow.Application.Queries;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;
using MeteorFlow.Auth.Roles.Queries;

namespace MeteorFlow.Auth.Users.Queries;

public class GetUsersQuery : IQuery<List<User>>
{
    public bool IncludeClaims { get; set; }
    public bool IncludeUserRoles { get; set; }
    public bool AsNoTracking { get; set; }
}

public class GetUsersQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUsersQuery, List<User>>
{
    public Task<List<User>> HandleAsync(GetUsersQuery query, CancellationToken cancellationToken = default)
    {
        var role = userRepository.Get(new UserQueryOptions
        {
            IncludeClaims = query.IncludeClaims,
            IncludeUserRoles = query.IncludeUserRoles,
            AsNoTracking = query.AsNoTracking,
        });

        return userRepository.ToListAsync(role);
    }
}