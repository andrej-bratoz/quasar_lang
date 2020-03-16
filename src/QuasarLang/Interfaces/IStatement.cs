namespace QuasarLang.Interfaces
{
    public interface IStatement
    {
        NodeMetadata Metadata { get; }
        string ToStringPretty();
    }
}