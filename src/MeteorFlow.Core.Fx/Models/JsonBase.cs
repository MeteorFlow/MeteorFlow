using System.ComponentModel.DataAnnotations;

namespace MeteorFlow.Core.Fx.Models;

public abstract class JsonBase<T> : Base<T> where T : IEquatable<T>
{
    [MaxLength(Int32.MaxValue)]
    public Dictionary<string, object> AdditionalProperties { get; set; }
}