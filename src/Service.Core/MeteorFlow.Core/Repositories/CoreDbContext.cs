using MeteorFlow.Core.Entities;
using MeteorFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Core.Repositories;

public class CoreDbContext(DbContextOptions<CoreDbContext> options) : DbContextUnitOfWork<CoreDbContext>(options)
{

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
        {
            modelBuilder.Entity<AppDefinitions>()
                .HasOne(ad => ad.BaseDefinition)
                .WithMany(ad => ad.SubDefinitions)
                .HasForeignKey(ad => ad.BaseDefinitionId);

            modelBuilder.Entity<AppDefinitions>()
                .HasMany(ad => ad.AppVersionControls)
                .WithOne(avc => avc.AppDefinition)
                .HasForeignKey(avc => avc.AppDefinitionId);

            modelBuilder.Entity<AppVersionControls>()
                .HasMany(avc => avc.AppInstances)
                .WithOne(ai => ai.AppliedVersion)
                .HasForeignKey(ai => ai.VersionId);

            // Adding indexes
            modelBuilder.Entity<AppDefinitions>()
                .HasIndex(ad => ad.BaseDefinitionId)
                .HasDatabaseName("ix_app_definitions_base_definition_id");

            modelBuilder.Entity<AppVersionControls>()
                .HasIndex(avc => avc.AppDefinitionId)
                .HasDatabaseName("ix_app_version_controls_app_definition_id");

            modelBuilder.Entity<AppInstances>()
                .HasIndex(ai => ai.VersionId)
                .HasDatabaseName("ix_app_instances_version_id");
        }
    }

    #endregion
}