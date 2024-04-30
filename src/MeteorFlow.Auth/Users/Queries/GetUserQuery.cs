using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;
using MeteorFlow.Fx.Queries;

namespace MeteorFlow.Auth.Users.Queries;

public class GetUserQuery : IQuery<User>
{
    public Guid Id { get; set; }
    public bool IncludeClaims { get; set; }
    public bool IncludeUserRoles { get; set; }
    public bool IncludeRoles { get; set; }
    public bool AsNoTracking { get; set; }
}

public class GetUserQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUserQuery, User>
{
    public Task<User> HandleAsync(GetUserQuery query, CancellationToken cancellationToken = default)
    {
        var db = userRepository.Get(new UserQueryOptions
        {
            IncludeClaims = query.IncludeClaims,
            IncludeUserRoles = query.IncludeUserRoles,
            IncludeRoles = query.IncludeRoles,
            AsNoTracking = query.AsNoTracking,
        });

        return userRepository.FirstOrDefaultAsync(db.Where(x => x.Id == query.Id));
    }
}
