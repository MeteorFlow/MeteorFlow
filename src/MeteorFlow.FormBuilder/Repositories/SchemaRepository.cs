using MeteorFlow.FormBuilder.Entities;
using MeteorFlow.Fx.DateTimes;

namespace MeteorFlow.FormBuilder.Repositories;

public class SchemaRepository(FormDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : Repository<ElementSchemas, Guid>(dbContext, dateTimeProvider), ISchemaRepository;