using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Repositories;

namespace MeteorFlow.Auth.Repositories;

public interface IAuthRepository<TEntity>: IRepository<TEntity, Guid> where TEntity : Entity<Guid>;