using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Fx.Entities;
using MeteorFlow.Infrastructure.Persistence;

namespace MeteorFlow.FormBuilder.Repositories;

public class Repository<T, TKey>(FormDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : DbContextRepository<FormDbContext, T, TKey>(dbContext, dateTimeProvider)
    where T : Entity<TKey>
    where TKey : IEquatable<TKey>;