using MeteorFlow.Auth.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MeteorFlow.Auth.Core.Persistence;

public class IdentityContext: IdentityDbContext<User, Roles, Guid>, IIdentityContext
{
    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
}