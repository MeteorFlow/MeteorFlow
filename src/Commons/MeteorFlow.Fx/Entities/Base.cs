namespace MeteorFlow.Fx.Entities;

public abstract class Base<T> : IHasKey<T> where T : IEquatable<T>
{
    public T Id { get; set; }
}