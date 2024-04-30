using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Infrastructure.Persistence;

namespace MeteorFlow.Auth.Repositories;

public class Repository<T, TKey>(IdentityDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : DbContextRepository<IdentityDbContext, T, TKey>(dbContext, dateTimeProvider)
    where T : Entity<TKey>
    where TKey : IEquatable<TKey>;