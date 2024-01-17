using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Infrastructure.Identity;

public class AccountContext : IAccountContext
{
    private readonly AccountManager _accountManager;

    public AccountContext(AccountManager accountManager)
    {
        _accountManager = accountManager;
    }

    public async Task<Account> GetByIdAsync(string id)
    {
        return await _accountManager.FindByIdAsync(id);
    }

    public Task<Account> GetByUserName(string userName)
    {
        return _accountManager.FindByNameAsync(userName);
    }

    public Task<bool> CheckPassword(Account account, string password)
    {
        return _accountManager.CheckPasswordAsync(account, password);
    }

    public Task<bool> IsExistUserName(string userName)
    {
        return _accountManager.Users.AnyAsync(account => account.UserName == userName);
    }

    public Task<IdentityResult> CreateAccount(Account account)
    {
        return _accountManager.CreateAsync(account, account.Password);
    }

    public async Task UpdateAsync(Account account)
    {
        await _accountManager.UpdateAsync(account);
    }

    public async Task UpdateSecurityStampAsync(Account account)
    {
        await _accountManager.UpdateSecurityStampAsync(account);
    }

    public async Task<bool> IncrementAccessFailedCountAsync(Account user)
    {
        var result = await _accountManager.AccessFailedAsync(user);
        return result.Succeeded;
    }

    public async Task<bool> IsUserLockedOutAsync(Account user)
    {
        var lockoutEndDate = await _accountManager.GetLockoutEndDateAsync(user);

        return (lockoutEndDate.HasValue && lockoutEndDate.Value > DateTimeOffset.Now);
    }

    public async Task ResetUserLockoutAsync(Account user)
    {
        await _accountManager.SetLockoutEndDateAsync(user, null);
        await _accountManager.ResetAccessFailedCountAsync(user);
    }
}