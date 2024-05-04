using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Infrastructure.Persistence;

namespace MeteorFlow.Infrastructure.Repositories;

public class VersionControlRepository(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : Repository<AppVersionControls, Guid>(dbContext, dateTimeProvider), IVersionControlRepository;