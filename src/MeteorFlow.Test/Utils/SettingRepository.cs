using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Fx.DateTimes;

namespace MeteorFlow.Test.Utils;

public class SettingRepository(TestDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : TestRepository<AppSettings, Guid>(dbContext, dateTimeProvider), ISettingRepository;