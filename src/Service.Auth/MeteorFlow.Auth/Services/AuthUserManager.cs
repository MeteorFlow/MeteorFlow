using MeteorFlow.Auth.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace MeteorFlow.Auth.Services;

public class AuthUserManager(
    IUserStore<User> store,
    IOptions<IdentityOptions> optionsAccessor,
    IPasswordHasher<User> passwordHasher,
    IEnumerable<IUserValidator<User>> userValidators,
    IEnumerable<IPasswordValidator<User>> passwordValidators,
    ILookupNormalizer keyNormalizer,
    IdentityErrorDescriber errors,
    IServiceProvider services,
    ILogger<AuthUserManager> logger)
    : UserManager<User>(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer,
        errors, services, logger)
{
    public async Task<SignInResult> CheckPasswordSignInAsync(User user, string password, bool lockoutOnFailure)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        var passwordVerificationResult = PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            if (lockoutOnFailure)
            {
                await AccessFailedAsync(user);
            }
            return SignInResult.Failed;
        }

        if (passwordVerificationResult == PasswordVerificationResult.SuccessRehashNeeded)
        {
            await UpdatePasswordHash(user, password, validatePassword: false);
            await UpdateAsync(user);
        }

        if (lockoutOnFailure)
        {
            await ResetAccessFailedCountAsync(user);
        }

        return SignInResult.Success;
    }

}