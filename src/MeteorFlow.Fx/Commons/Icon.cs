namespace MeteorFlow.Fx.Commons;

public readonly struct Icon(string code)
{
    public static readonly Icon Empty = new();
    
    public override string ToString()
    {
        return code;
    }
}