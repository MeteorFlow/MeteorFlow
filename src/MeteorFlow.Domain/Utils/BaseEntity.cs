
namespace MeteorFlow.Domain.Utils;

public abstract class BaseEntity<T> where T : IEquatable<T>
{
  public virtual T Id { get; set; }
}