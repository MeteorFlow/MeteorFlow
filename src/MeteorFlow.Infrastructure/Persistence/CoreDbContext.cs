using MeteorFlow.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Infrastructure.Persistence;

public class CoreDbContext : DbContextUnitOfWork<CoreDbContext>
{
    #region Ctor

    public CoreDbContext(DbContextOptions<CoreDbContext> options)
        : base(options)
    {
    }

    #endregion

    #region DbSet

    public DbSet<AppDefinitions> AppDefinitions { get; set; }
    public DbSet<AppInstances> AppInstances { get; set; }
    public DbSet<AppVersionControls> AppVersionControls { get; set; }
    public DbSet<AppSettings> AppSettings { get; set; }


    #endregion

    #region Methods

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppDefinitions>()
            .HasOne(c => c.BaseDefinition)
            .WithMany()
            .OnDelete(DeleteBehavior.NoAction);
    }

    #endregion
}