using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MeteorFlow.Core.Extensions;
using MeteorFlow.Domain;
using MeteorFlow.Domain.Utils;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Core.Services.Users;

public class UsersService(ICoreDbContext context, IMapper mapper) : IUsersService
{
    public async ValueTask<ICollection<Profiles>> GetAllUsersAsync()
    {
        var entities = await context.Profiles.ToListAsync();
        return mapper.Map<IList<Profiles>>(entities);
    }

    public async ValueTask<ICollection<Accounts>> GetAllAccountsAsync()
    {
        var entities = await context.Accounts.Include(account => account.Profile).ToListAsync();
        return mapper.Map<IList<Accounts>>(entities);
    }

    public async ValueTask<Profiles> GetById(int id)
    {
        var entity = await context.Profiles.FirstOrDefaultAsync(user => user.Id == id);
        return mapper.Map<Profiles>(entity);
    }

    public async ValueTask<Profiles> GetById(BaseEntity<int> domain)
    {
        var entity = await context.Profiles.FirstOrDefaultAsync(user => user.Id == domain.Id);
        return mapper.Map<Profiles>(entity);
    }

    public async ValueTask UpdateAsync(ICollection<Profiles> users)
    {
        foreach (var user in users)
        {
            var entity = await context.Profiles
                .FirstOrDefaultAsync(s => s.Id == user.Id);

            if (entity is null)
            {
                throw new ValidationException($"Invalid: {user.Id} is not existed.");
            }
            context.Profiles.Entry(entity).CurrentValues.SetValues(mapper.Map<Entities.Profiles>(user));
            await context.SaveChangesAsync();
        }
    }

    public async ValueTask RemoveAsync(int id)
    {
        var entity = await context.Accounts.Include(t => t.Profile).Where(t => t.Id == id).FirstOrDefaultAsync();
        if (entity is null)
        {
            throw new ValidationException($"Invalid: {id} is not existed.");
        }

        context.Profiles.Remove(entity.Profile);

        context.Accounts.Remove(entity);
        await context.SaveChangesAsync();
    }
}