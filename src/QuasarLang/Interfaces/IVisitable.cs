namespace QuasarLang.Interfaces
{
    public interface IVisitable
    {
        NodeMetadata Metadata { get; }
        void Accept(IVisitor visitor);
    }
}