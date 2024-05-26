using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.DateTimes;

namespace MeteorFlow.Core.Repositories;

public class VersionControlRepository(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider) 
    : Repository<AppVersionControls, Guid>(dbContext, dateTimeProvider), IVersionControlRepository;