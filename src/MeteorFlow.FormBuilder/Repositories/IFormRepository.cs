using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Repositories;

namespace MeteorFlow.FormBuilder.Repositories;

public interface IFormRepository<TEntity>: IRepository<TEntity, Guid> where TEntity : Entity<Guid>;