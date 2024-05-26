using MeteorFlow.FormBuilder.Entities;
using MeteorFlow.Fx.DateTimes;

namespace MeteorFlow.FormBuilder.Repositories;

public class ElementRepository(FormDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : Repository<FormElements, Guid>(dbContext, dateTimeProvider), IElementRepository;