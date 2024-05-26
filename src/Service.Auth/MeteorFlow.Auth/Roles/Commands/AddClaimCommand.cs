using MeteorFlow.Application.Commands;
using MeteorFlow.Auth.Entities;
using MeteorFlow.Auth.Repositories;

namespace MeteorFlow.Auth.Roles.Commands;

public class AddClaimCommand: ICommand<Entities.Role>
{
    public Entities.Role Role { get; set; }
    public RoleClaims Claim { get; set; }
}

public class AddClaimCommandHandler(IRoleRepository roleRepository) : ICommandHandler<AddClaimCommand, Entities.Role>
{
    public async Task<Entities.Role> HandleAsync(AddClaimCommand command, CancellationToken cancellationToken = default)
    {
        command.Role.Claims.Add(command.Claim);
        await roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return command.Role;
    }
}