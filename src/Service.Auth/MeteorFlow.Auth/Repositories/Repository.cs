using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Infrastructure.Persistence;

namespace MeteorFlow.Auth.Repositories;

public class Repository<T, TKey>(AuthDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : DbContextRepository<AuthDbContext, T, TKey>(dbContext, dateTimeProvider)
    where T : Entity<TKey>
    where TKey : IEquatable<TKey>;