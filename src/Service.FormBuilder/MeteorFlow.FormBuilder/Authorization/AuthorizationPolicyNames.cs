namespace MeteorFlow.FormBuilder.Authorization;

public static class AuthorizationPolicyNames
{
    public const string GetFormsPolicy = "GetFormsPolicy";
    public const string GetFormPolicy = "GetFormPolicy";
    public const string AddFormPolicy = "AddFormPolicy";
    public const string UpdateFormPolicy = "UpdateFormPolicy";
    public const string DeleteFormPolicy = "DeleteFormPolicy";
    public const string GetFormAuditLogsPolicy = "GetFormAuditLogsPolicy";

    public static IEnumerable<string> GetPolicyNames()
    {
        yield return GetFormsPolicy;
        yield return GetFormPolicy;
        yield return AddFormPolicy;
        yield return UpdateFormPolicy;
        yield return DeleteFormPolicy;
        yield return GetFormAuditLogsPolicy;
    }
}