namespace QuasarLang.AST
{
    public interface IStatement
    {
        NodeMetadata Metadata { get; }
        string ToStringPretty();
    }
}