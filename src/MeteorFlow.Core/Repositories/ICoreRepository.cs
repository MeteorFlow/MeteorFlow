using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Repositories;

namespace MeteorFlow.Core.Repositories;

public interface ICoreRepository<TEntity>: IRepository<TEntity, Guid> where TEntity : Entity<Guid>;