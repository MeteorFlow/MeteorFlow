namespace MeteorFlow.Auth.Models;

public class PasswordSetter
{
    public Guid Id { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public string ConfirmPassword { get; set; }
}
