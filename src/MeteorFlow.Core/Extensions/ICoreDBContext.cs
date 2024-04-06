using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Entities.App;
using MeteorFlow.Core.Entities.Forms;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Core.Extensions;

public interface ICoreDbContext
{
    DbSet<AppDefinitions> AppDefinitions { get; set; }
    DbSet<AppInstances> AppInstances { get; set; }
    DbSet<AppVersionControls> AppVersionControls { get; set; }
    DbSet<AppSettings> AppSettings { get; set; }
    DbSet<Users> Users { get; set; }
    DbSet<Tenants> Tenants { get; set; }
    DbSet<FormBlocks> FormBlocks { get; set; }
    DbSet<FormElements> FormElements { get; set; }
    DbSet<ElementSchemas> ElementSchemas { get; set; }
    
    Task<int> SaveChangesAsync();
}