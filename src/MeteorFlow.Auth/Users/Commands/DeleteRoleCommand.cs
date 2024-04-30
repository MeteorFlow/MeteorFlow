using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;
using MeteorFlow.Fx.Commands;

namespace MeteorFlow.Auth.Users.Commands;

public class DeleteRoleCommand : ICommand<User>
{
    public User User { get; set; }
    public UserRole Role { get; set; }
}

public class DeleteRoleCommandHandler(IUserRepository userRepository) : ICommandHandler<DeleteRoleCommand, User>
{
    public async Task<User> HandleAsync(DeleteRoleCommand command, CancellationToken cancellationToken = default)
    {
        command.User.UserRoles.Remove(command.Role);
        await userRepository.AddOrUpdateAsync(command.User);
        await userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return command.User;
    }
}
