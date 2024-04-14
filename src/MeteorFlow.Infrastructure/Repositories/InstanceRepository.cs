using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Fx.Repositories;
using MeteorFlow.Infrastructure.Persistence;

namespace MeteorFlow.Infrastructure.Repositories;

public class InstanceRepository(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : Repository<AppInstances, Guid>(dbContext, dateTimeProvider), IInstanceRepository;