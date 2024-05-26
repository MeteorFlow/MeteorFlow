using System.Reflection;
using MeteorFlow.FormBuilder.Entities;
using MeteorFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.FormBuilder.Repositories;


public class FormDbContext(DbContextOptions<FormDbContext> options) : DbContextUnitOfWork<FormDbContext>(options)
{
    public DbSet<FormBlocks> FormBlocks { get; set; }

    public DbSet<FormElements> FormElements { get; set; }

    public DbSet<ElementSchemas> ElementSchemas { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}