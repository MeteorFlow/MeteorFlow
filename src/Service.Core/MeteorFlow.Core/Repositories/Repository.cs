using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Infrastructure.Persistence;

namespace MeteorFlow.Core.Repositories;

public class Repository<T, TKey>(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : DbContextRepository<CoreDbContext, T, TKey>(dbContext, dateTimeProvider)
    where T : Entity<TKey>
    where TKey : IEquatable<TKey>;