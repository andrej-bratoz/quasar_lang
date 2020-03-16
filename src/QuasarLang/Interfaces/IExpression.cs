namespace QuasarLang.Interfaces
{
    public interface IExpression
    {
        dynamic Value { get; set; }
        string ToStringPretty();
    }
}