using MeteorFlow.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MeteorFlow.Infrastructure.Identity;

public class AccountManager(
    IUserStore<Account> store,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<Account> passwordHasher,
    IEnumerable<IUserValidator<Account>> userValidators,
    IEnumerable<IPasswordValidator<Account>> passwordValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<AccountManager> logger)
    : UserManager<Account>(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer,
        errors, services, logger);