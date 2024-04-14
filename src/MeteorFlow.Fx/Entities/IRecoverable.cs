namespace MeteorFlow.Fx.Entities;

public interface IRecoverable
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
    public DateTimeOffset? DeleteDate { get; set; }
    public byte[] RowVersion { get; set; }
}