using System.Reflection;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Infrastructure.Persistence;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Auth.Repositories;


public class AuthDbContext(DbContextOptions<AuthDbContext> options)
    : DbContextUnitOfWork<AuthDbContext>(options), IDataProtectionKeyContext
{
    public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRole> UserRole { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        // Seed roles
        builder.Entity<Role>().HasData(
            new Role
            {
                Id = new Guid("a1b1c1d1-e1f1-1234-5678-9abcdef12345"),
                Name = "User",
                NormalizedName = "USER",
                CreatedDate = DateTimeOffset.UtcNow
            },
            new Role
            {
                Id = new Guid("a2b2c2d2-e2f2-1234-5678-9abcdef12345"),
                Name = "Tenant",
                NormalizedName = "TENANT",
                CreatedDate = DateTimeOffset.UtcNow
            }
        );
    
    }
}