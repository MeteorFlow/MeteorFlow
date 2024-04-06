using MeteorFlow.Cloud.Auth.Persistence;
using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Fx.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using IdentityRole = MeteorFlow.Core.Fx.Identities.IdentityRole;

namespace MeteorFlow.Cloud.Auth.Providers;

public class IdentityStore(IdentityContext context, IdentityErrorDescriber describer = null)
    : UserStore<IdentityBase, Roles, IdentityContext, Guid, IdentityClaims, IdentityRole, IdentityLogins, IdentityTokens,
        RoleClaims>(context, describer);