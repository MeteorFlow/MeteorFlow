namespace MeteorFlow.Auth;

public static class Constants
{
    public const string AllowedUserNameCharacters =
        "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._+";
    public const string UserEmailClaimType = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress";
    public const string PersistenceDb = "PersistenceDb";
}