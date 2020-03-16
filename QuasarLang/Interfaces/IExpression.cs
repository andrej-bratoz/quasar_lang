namespace QuasarLang
{
    public interface IExpression
    {
        dynamic Value { get; set; }
        string ToStringPretty();
    }
}