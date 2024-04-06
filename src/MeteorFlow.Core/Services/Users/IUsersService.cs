using MeteorFlow.Domain.Utils;

namespace MeteorFlow.Core.Services.Users;
using Domain;

public interface IUsersService
{
    ValueTask<ICollection<Users>> GetAllUsersAsync();
    ValueTask<ICollection<Accounts>> GetAllAccountsAsync();
    ValueTask<Users> GetById(int id);
    ValueTask<Users> GetById(BaseEntity<int> id);
    ValueTask UpdateAsync(ICollection<Users> users);
    ValueTask RemoveAsync(int id);
}