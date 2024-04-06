namespace MeteorFlow.Core.Fx.Commons;

public interface IRecoverable
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
    public DateTimeOffset? DeleteTime { get; set; }
}