namespace QuasarLang.Interfaces
{
    public interface IExpression
    {
        int ScopeLevel { get; set; }
        dynamic Value { get; set; }
        string ToStringPretty();
    }
}