using MeteorFlow.Application.Commands;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;
using Microsoft.EntityFrameworkCore;

namespace MeteorFlow.Auth.Users.Commands;

public class SaveUserCommand: ICommand<User>
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}

internal class SaveUserCommandHandler(IUserRepository userRepository) : ICommandHandler<SaveUserCommand, User>
{
    public async Task<User> HandleAsync(SaveUserCommand command, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.Get(new UserQueryOptions()).FirstOrDefaultAsync(u => u.Id == command.UserId, cancellationToken: cancellationToken);
        user.UserName = command.UserName;
        user.Email = command.Email;
        await userRepository.AddOrUpdateAsync(user, cancellationToken);
        await userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return user;
    }
}