using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Infrastructure.Persistence;

namespace MeteorFlow.Infrastructure.Repositories;

public class Repository<T, TKey> : DbContextRepository<CoreDbContext, T, TKey> 
    where T : Entity<TKey> where TKey : IEquatable<TKey>
{
    public Repository(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider)
        : base(dbContext, dateTimeProvider)
    {
    }
}
