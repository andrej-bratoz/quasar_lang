namespace QuasarLang.Interfaces
{
    public interface IStatement
    {
        int ScopeLevel { get; set; }
        NodeMetadata Metadata { get; }
        string ToStringPretty();
    }
}