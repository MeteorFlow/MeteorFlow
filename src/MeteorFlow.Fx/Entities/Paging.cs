namespace MeteorFlow.Fx.Entities;

public class Paged<T>
{
    public long TotalItems { get; set; }

    public List<T> Items { get; set; }
}