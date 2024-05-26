using MeteorFlow.Core.Entities;
using MeteorFlow.Fx.DateTimes;

namespace MeteorFlow.Core.Repositories;

public class DefinitionRepository(CoreDbContext dbContext, IDateTimeProvider dateTimeProvider) 
    : Repository<AppDefinitions, Guid>(dbContext, dateTimeProvider), IDefinitionRepository;