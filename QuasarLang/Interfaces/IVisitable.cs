namespace QuasarLang
{
    public interface IVisitable
    {
        NodeMetadata Metadata { get; }
        void Accept(IVisitor visitor);
    }
}