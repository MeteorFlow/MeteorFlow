
namespace MeteorFlow.Fx.Entities;

public interface IHasKey<T> where T : IEquatable<T>
{ 
    T Id { get; set; }
}