using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Infrastructure.Persistence;

namespace MeteorFlow.Infrastructure.Repositories;

public class DefinitionRepository(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : Repository<AppDefinitions, Guid>(dbContext, dateTimeProvider), IDefinitionRepository;