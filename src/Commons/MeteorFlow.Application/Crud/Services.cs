using MeteorFlow.Fx.Entities;
using MeteorFlow.Fx.Exceptions;
using MeteorFlow.Fx.Repositories;

namespace MeteorFlow.Application.Crud;

public class Services<TEntity, TKey>(IRepository<TEntity, TKey> repository) : IServices<TEntity, TKey>
    where TEntity : Entity<TKey>
    where TKey : IEquatable<TKey>
{
    private readonly IUnitOfWork _unitOfWork = repository.UnitOfWork;
    protected readonly IRepository<TEntity, TKey> Repository = repository;


    public async Task<List<TEntity>> GetAsync(CancellationToken cancellationToken = default)
    {
        return await Repository.ToListAsync(Repository.GetQueryableSet());
    }

    public async Task<TEntity> GetByIdAsync(TKey id, CancellationToken cancellationToken = default)
    {
        ValidationException.Requires(!id.Equals(default), "Invalid Id");
        return await Repository.FirstOrDefaultAsync(Repository.GetQueryableSet().Where(x => x.Id.Equals(id)));
    }

    public async Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity.Id.Equals(default))
        {
            return await AddAsync(entity, cancellationToken);
        }
        var data = await GetByIdAsync(entity.Id, cancellationToken);
        if (data is null)
        {
            return await AddAsync(entity, cancellationToken);
        }

        return await UpdateAsync(entity, cancellationToken);
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await Repository.AddAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = await Repository.UpdateAsync(entity, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return result;
    }

    public async Task<TEntity> DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        Repository.Delete(entity);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return entity;
    }
}