namespace MeteorFlow.Fx.Entities;

public abstract class Entity<T>: IRecoverable, IHasKey<T> where T: IEquatable<T>
{
    public DateTimeOffset CreatedDate { get; set; }
    public DateTimeOffset? LastModifiedDate { get; set; }
    public DateTimeOffset? DeleteDate { get; set; }
    public byte[] RowVersion { get; set; }
    public T Id { get; set; }
}