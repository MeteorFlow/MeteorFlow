
namespace MeteorFlow.Fx.Models;

public abstract class Base<T> where T : IEquatable<T>
{
  public virtual T Id { get; set; }
}