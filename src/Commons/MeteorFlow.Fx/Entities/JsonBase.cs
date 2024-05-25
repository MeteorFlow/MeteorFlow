namespace MeteorFlow.Fx.Entities;

public abstract class JsonBase<T> : Base<T>, IJson where T : IEquatable<T>
{
    public Dictionary<string, object> Metadata { get; set; }
}