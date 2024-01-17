using MeteorFlow.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace MeteorFlow.Core.Extensions;

public interface IAccountContext
{
    Task<Account> GetByIdAsync(string id);
    Task<Account> GetByUserName(string userName);
    Task<bool> CheckPassword(Account account, string password);
    Task<bool> IsExistUserName(string userName);
    Task<IdentityResult> CreateAccount(Account account);
    Task UpdateAsync(Account account);
    Task UpdateSecurityStampAsync(Account account);
    Task<bool> IncrementAccessFailedCountAsync(Account user);
    Task<bool> IsUserLockedOutAsync(Account user);
    Task ResetUserLockoutAsync(Account user);
}