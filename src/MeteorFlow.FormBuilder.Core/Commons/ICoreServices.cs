using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Services;

namespace MeteorFlow.FormBuilder.Core.Commons;

internal interface ICoreServices<TEntity>: IServices<TEntity, Guid> where TEntity : Entity<Guid>;