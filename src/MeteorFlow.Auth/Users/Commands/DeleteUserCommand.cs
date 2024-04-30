using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;
using MeteorFlow.Fx.Commands;

namespace MeteorFlow.Auth.Users.Commands;

public class DeleteUserCommand : ICommand<User>
{
    public User User { get; set; }
}

public class DeleteUserCommandHandler(IUserRepository userRepository) : ICommandHandler<DeleteUserCommand, User>
{
    public async Task<User> HandleAsync(DeleteUserCommand command, CancellationToken cancellationToken = default)
    {
        userRepository.Delete(command.User);
        await userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return command.User;
    }
}
