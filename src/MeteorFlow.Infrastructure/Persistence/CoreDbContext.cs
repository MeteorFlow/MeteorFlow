using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Entities.App;
using MeteorFlow.Core.Entities.Forms;
using MeteorFlow.Core.Extensions;
using MeteorFlow.Core.Fx.Identities;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Infrastructure.Persistence;

public class CoreDbContext : DbContext, ICoreDbContext
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
    public DbSet<Users> Users { get; set; }
    public DbSet<Tenants> Tenants { get; set; }
    public DbSet<FormBlocks> FormBlocks { get; set; }
    public DbSet<FormElements> FormElements { get; set; }
    public DbSet<ElementSchemas> ElementSchemas { get; set; }
    public DbSet<Roles> Roles { get; set; }

    #endregion

    #region Methods

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }

    #endregion
}