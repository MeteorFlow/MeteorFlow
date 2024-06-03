namespace MeteorFlow.Domain.Commons;

public interface IObject
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Icon? Icon { get; set; }
}