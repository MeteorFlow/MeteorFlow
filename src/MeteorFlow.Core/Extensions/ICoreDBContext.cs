using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Entities.Tenants;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Core.Extensions;

public interface ICoreDbContext
{
    DbSet<AppSettings> AppSettings { get; set; }
    DbSet<Profiles> Profiles { get; set; }
    DbSet<Stations> Stations { get; set; }
    DbSet<ObservationElements> ObservationElements { get; set; }
    DbSet<ObservationValues> ObservationValues { get; set; }
    DbSet<Units> Units { get; set; }
    DbSet<Account> Accounts { get; set; }
    DbSet<AccountClaim> AccountClaims { get; set; }
    DbSet<AccountLogins> AccountLogins { get; set; }
    DbSet<AccountTokens> AccountTokens { get; set; }
    DbSet<AccountRole> AccountRoles { get; set; }
    DbSet<RoleClaims> RoleClaims { get; set; }
    DbSet<Roles> Roles { get; set; }
    

    Task<int> SaveChangesAsync();
}