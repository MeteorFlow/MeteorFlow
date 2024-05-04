using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;
using MeteorFlow.Fx.Commands;

namespace MeteorFlow.Auth.Users.Commands;

public class AddRoleCommand : ICommand<User>
{
    public User User { get; set; }
    public UserRole Role { get; set; }
}

public class AddRoleCommandHandler(IUserRepository userRepository) : ICommandHandler<AddRoleCommand, User>
{
    public async Task<User> HandleAsync(AddRoleCommand command, CancellationToken cancellationToken = default)
    {
        command.User.UserRoles.Add(command.Role);
        await userRepository.AddOrUpdateAsync(command.User, cancellationToken);
        await userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return command.User;
    }
}