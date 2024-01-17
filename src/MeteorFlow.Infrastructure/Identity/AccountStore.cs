using MeteorFlow.Core.Entities;
using MeteorFlow.Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MeteorFlow.Infrastructure.Identity;

public class AccountStore(CoreDbContext context, IdentityErrorDescriber describer = null)
    : UserStore<Account, Roles, CoreDbContext, int, AccountClaim, AccountRole, AccountLogins, AccountTokens,
        RoleClaims>(context, describer);