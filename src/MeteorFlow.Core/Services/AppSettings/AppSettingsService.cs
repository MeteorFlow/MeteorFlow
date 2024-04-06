using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MeteorFlow.Core.Extensions;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Core.Services.AppSettings;

public class AppSettingsService(ICoreDbContext context, IMapper mapper) : IAppSettingsService
{
    public async ValueTask<ICollection<Domain.App.AppSettings>> GetAllAsync()
    {
        var entities = await context.AppSettings.ToListAsync();
        return mapper.Map<IList<Domain.App.AppSettings>>(entities);
    }

    public async ValueTask<Domain.App.AppSettings?> GetById(string referenceKey)
    {
        var entities = await context.AppSettings.ToListAsync();
        var result = entities.Find(t => t.Name == referenceKey);
        return mapper.Map<Domain.App.AppSettings>(result);
    }

    public async ValueTask UpdateAsync(ICollection<Domain.App.AppSettings> settings)
    {
        foreach (var setting in settings)
        {
            var entity = await context.AppSettings
                .FirstOrDefaultAsync(s => s.Id == setting.Id);

            if (entity is null)
            {
                throw new ValidationException($"Invalid: {setting.ReferenceKey} is not existed.");
            }
            context.AppSettings.Entry(entity).CurrentValues.SetValues(mapper.Map<Entities.App.AppSettings>(setting));
            await context.SaveChangesAsync();
        }
    }

    public async ValueTask<Domain.App.AppSettings> AddAsync(Domain.App.AppSettings setting)
    {
        if (string.IsNullOrWhiteSpace(setting.ReferenceKey))
        {
            throw new ValidationException($"Invalid: {nameof(Domain.App.AppSettings.ReferenceKey)} should not be empty.");
        }

        var entity = context.AppSettings.Add(mapper.Map<Entities.App.AppSettings>(setting)).Entity;
        await context.SaveChangesAsync();
        return mapper.Map<Domain.App.AppSettings>(entity);
    }

    public async ValueTask Remove(string id)
    {
        var entities = await context.AppSettings.ToListAsync();
        var result = entities.Find(t => t.Id.ToString() == id);

        if (result is null)
        {
            throw new ValidationException($"Invalid: {id} is not existed.");
        }

        context.AppSettings.Remove(result);
        await context.SaveChangesAsync();
    }
}