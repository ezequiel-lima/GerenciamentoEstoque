using GerenciamentoEstoque.Shared.Commands;

namespace GerenciamentoEstoque.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handler(T command);
    }
}
