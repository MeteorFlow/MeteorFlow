using MeteorFlow.Core.Fx.Identities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MeteorFlow.Cloud.Auth.Providers;

public class IdentityManager(
    IUserStore<IdentityBase> store,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<IdentityBase> passwordHasher,
    IEnumerable<IUserValidator<IdentityBase>> userValidators,
    IEnumerable<IPasswordValidator<IdentityBase>> passwordValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<IdentityManager> logger)
    : UserManager<IdentityBase>(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer,
        errors, services, logger);