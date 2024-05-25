using MeteorFlow.Domain.Files;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace MeteorFlow.Core.Api.Authorizations;

public class FileEntryAuthorizationHandler : AuthorizationHandler<OperationAuthorizationRequirement, FileEntry>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, OperationAuthorizationRequirement requirement, FileEntry resource)
    {
        // TODO: check CreatedById
        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}