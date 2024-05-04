using MeteorFlow.FormBuilder.Entities;
using MeteorFlow.Fx.DateTimes;

namespace MeteorFlow.FormBuilder.Repositories;

public class BlockRepository(FormDbContext dbContext, IDateTimeProvider dateTimeProvider)
    : Repository<FormBlocks, Guid>(dbContext, dateTimeProvider), IBlockRepository;
