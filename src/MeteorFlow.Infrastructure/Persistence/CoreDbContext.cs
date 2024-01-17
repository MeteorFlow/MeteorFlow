using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Extensions;
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

    public DbSet<AppSettings> AppSettings { get; set; }
    public DbSet<Profiles> Profiles { get; set; }
    public DbSet<Stations> Stations { get; set; }
    public DbSet<ObservationElements> ObservationElements { get; set; }
    public DbSet<ObservationValues> ObservationValues { get; set; }
    public DbSet<Units> Units { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<AccountClaim> AccountClaims { get; set; }
    public DbSet<AccountLogins> AccountLogins { get; set; }
    public DbSet<AccountTokens> AccountTokens { get; set; }
    public DbSet<AccountRole> AccountRoles { get; set; }
    public DbSet<RoleClaims> RoleClaims { get; set; }
    public DbSet<Roles> Roles { get; set; }

    #endregion

    #region Methods

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountClaim>()
            .HasOne(u => u.Account)
            .WithMany(u => u.Claims)
            .HasForeignKey(u => u.UserId);
        modelBuilder.Entity<RoleClaims>()
            .HasOne(u => u.Role)
            .WithMany(u => u.Claims)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<AccountLogins>()
            .HasOne(u => u.Account)
            .WithMany(u => u.AccountLogins)
            .HasForeignKey(u => u.UserId);
        modelBuilder.Entity<AccountRole>()
            .HasOne(u => u.Account)
            .WithMany(u => u.AccountRoles)
            .HasForeignKey(u => u.UserId);
        modelBuilder.Entity<AccountRole>()
            .HasOne(u => u.Role)
            .WithMany(u => u.Users)
            .HasForeignKey(u => u.RoleId);
        modelBuilder.Entity<AccountTokens>()
            .HasOne(u => u.Account)
            .WithMany(u => u.AccountTokens)
            .HasForeignKey(u => u.UserId);
    }

    #endregion
}