using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Entities.App;
using MeteorFlow.Core.Extensions;
using MeteorFlow.Core.Fx.Identities;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Test.Utils;

public class TestDbContext : DbContext, ICoreDbContext
{
    public virtual DbSet<AppSettings> AppSettings { get; set; }
    public DbSet<Profiles> Profiles { get; set; }
    public DbSet<Department> Stations { get; set; }
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

    public Task<int> SaveChangesAsync()
    {
        return base.SaveChangesAsync();
    }
    public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
    {
    }
}