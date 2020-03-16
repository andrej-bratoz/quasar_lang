using QuasarLang.AST;

namespace QuasarLang.Interfaces
{
    public interface IVisitor
    {
        void Visit(StrLiteral arg);
        void Visit(NumericLiteral arg);
    }
}