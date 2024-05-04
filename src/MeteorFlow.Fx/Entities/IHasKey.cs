
namespace MeteorFlow.Fx.Entities;

public interface IHasKey<T>
{ 
    T Id { get; set; }
}