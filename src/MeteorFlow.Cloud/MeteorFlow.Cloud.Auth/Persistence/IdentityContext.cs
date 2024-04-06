using MeteorFlow.Core.Fx.Identities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MeteorFlow.Cloud.Auth.Persistence;

public class IdentityContext: IdentityDbContext<IdentityBase, Roles, Guid>
{
    
}