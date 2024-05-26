using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.DateTimes;

namespace MeteorFlow.Core.Repositories;

public class SettingRepository(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider) 
    : Repository<AppSettings, Guid>(dbContext, dateTimeProvider), ISettingRepository;