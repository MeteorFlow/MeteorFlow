using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.DateTimes;

namespace MeteorFlow.Core.Repositories;

public class InstanceRepository(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider) 
    : Repository<AppInstances, Guid>(dbContext, dateTimeProvider), IInstanceRepository;