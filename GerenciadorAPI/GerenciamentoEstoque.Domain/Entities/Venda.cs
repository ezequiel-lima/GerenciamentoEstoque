using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class Venda : Entity
    {
        protected Venda() { }

        public Venda(Guid produtoId, DateTime data, int quantidade)
        {
            ProdutoId = produtoId;
            Data = data;
            Quantidade = quantidade;
        }

        public Guid ProdutoId { get; private set; }
        public DateTime Data { get; private set; }
        public int Quantidade { get; private set; }
    }
}