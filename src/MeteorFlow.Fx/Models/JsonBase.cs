namespace MeteorFlow.Fx.Models;

public abstract class JsonBase<T> : Base<T> where T : IEquatable<T>
{
    public Dictionary<string, object> AdditionalProperties { get; set; }
}