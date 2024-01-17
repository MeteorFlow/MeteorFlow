using MeteorFlow.Domain;

namespace MeteorFlow.Core.Services.Users;

public interface IAccountService
{
    ValueTask UpdateAsync(Accounts accounts);
    ValueTask<Accounts> AddAsync(Accounts accounts);
    ValueTask SignInAsync(LoginInfo loginInfo);
    ValueTask SignOutAsync(string id);
}