using System.Reflection;
using MeteorFlow.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.FormBuilder.Repositories;


public class FormDbContext : DbContextUnitOfWork<FormDbContext>
{
    public FormDbContext(DbContextOptions<FormDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}