using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Repositories;

namespace MeteorFlow.Auth.Core.Repositories;

public interface IAuthRepository<TEntity>: IRepository<TEntity, Guid> where TEntity : Entity<Guid>;