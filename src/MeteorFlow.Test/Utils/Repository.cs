using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Infrastructure.Persistence;

namespace MeteorFlow.Test.Utils;

public class TestRepository<T, TKey>(TestDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : DbContextRepository<TestDbContext, T, TKey>(dbContext, dateTimeProvider)
    where T : Entity<TKey>
    where TKey : IEquatable<TKey>;
