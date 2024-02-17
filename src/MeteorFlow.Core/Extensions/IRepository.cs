namespace MeteorFlow.Core.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IRepository<TEntity> where TEntity : class
{
    // Create
    ValueTask AddAsync(TEntity entity);

    // Read
    ValueTask<TEntity> GetByIdAsync(int id);
    ValueTask<IEnumerable<TEntity>> GetAllAsync();

    // Update
    ValueTask UpdateAsync(TEntity entity);

    // Delete
    ValueTask RemoveAsync(TEntity entity);
}