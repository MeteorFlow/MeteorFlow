using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Repositories;
using MeteorFlow.Fx.DateTimes;
using MeteorFlow.Infrastructure.Persistence;
using MeteorFlow.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Test.Utils;

public class TestDbContext : DbContextUnitOfWork<TestDbContext>
{
    public DbSet<AppDefinitions> AppDefinitions { get; set; }
    public DbSet<AppInstances> AppInstances { get; set; }
    public DbSet<AppVersionControls> AppVersionControls { get; set; }
    public DbSet<AppSettings> AppSettings { get; set; }


    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }
}

