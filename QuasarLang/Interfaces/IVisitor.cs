using QuasarLang.AST;

namespace QuasarLang
{
    public interface IVisitor
    {
        void Visit(StrLiteral arg);
    }
}