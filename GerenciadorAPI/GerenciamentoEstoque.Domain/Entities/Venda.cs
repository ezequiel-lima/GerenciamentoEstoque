using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class Venda : Entity
    {
        protected Venda() { }

        public Venda(Produto produto, DateTime data, int quantidade)
        {
            Produto = produto;
            Data = data;
            Quantidade = quantidade;
        }

        public Produto Produto { get; private set; }
        public DateTime Data { get; private set; }
        public int Quantidade { get; private set; }
    }
}