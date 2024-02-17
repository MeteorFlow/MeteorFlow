using System.ComponentModel.DataAnnotations;
using AutoMapper;
using MeteorFlow.Core.Entities;
using MeteorFlow.Core.Extensions;
using MeteorFlow.Domain;
using Profiles = MeteorFlow.Domain.Profiles;

namespace MeteorFlow.Core.Services.Users;

public class AccountService(IMapper mapper, IAccountContext accountContext) : IAccountService
{
    public async ValueTask UpdateAsync(Accounts accounts)
    {
        await accountContext.UpdateAsync(mapper.Map<Account>(accounts));
    }

    public async ValueTask<Accounts> AddAsync(Accounts accounts)
    {
        
        accounts.Profile ??= new Profiles();
        var result = await accountContext.CreateAccount(mapper.Map<Account>(accounts));

        if (!result.Succeeded)
        {
            throw new ValidationException(result.ToString());
        }
        return accounts;
    }

    public async ValueTask SignInAsync(LoginInfo loginInfo)
    {
        var account = await accountContext.GetByUserName(loginInfo.Name);
        if (account is null)
        {
            throw new ValidationException("Invalid Credentials.");
        }

        var succeed = await accountContext.CheckPassword(account, loginInfo.Password);
        if (!succeed)
        {
            throw new ValidationException("Login failed.");
        }
    }

    public async ValueTask SignOutAsync(string id)
    {
        var account = await accountContext.GetByIdAsync(id);
        if (account is null)
        {
            throw new ValidationException("Invalid Credentials.");
        }
        await accountContext.UpdateSecurityStampAsync(account);
    }
}