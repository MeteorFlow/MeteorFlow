using MeteorFlow.Auth.Core.Entities;
using MeteorFlow.Auth.Core.Repositories;
using MeteorFlow.Fx.Commands;

namespace MeteorFlow.Auth.Core.Commands;

public class AddClaimCommand: ICommand<Roles>
{
    public Roles Role { get; set; }
    public RoleClaims Claim { get; set; }
}

public class AddClaimCommandHandler(IRoleRepository roleRepository) : ICommandHandler<AddClaimCommand, Roles>
{
    public async Task<Roles> HandleAsync(AddClaimCommand command, CancellationToken cancellationToken = default)
    {
        command.Role.Claims.Add(command.Claim);
        await roleRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return command.Role;
    }
}