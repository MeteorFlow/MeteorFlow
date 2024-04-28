using MeteorFlow.Auth.Core.Entities;
using MeteorFlow.Auth.Core.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MeteorFlow.Auth.Core.Providers;

public class IdentityStore(IdentityContext context, IdentityErrorDescriber describer = null)
    : UserStore<User, Roles, IdentityContext, Guid, UserClaims, UserRole, UserLogins, UserTokens,
        RoleClaims>(context, describer);