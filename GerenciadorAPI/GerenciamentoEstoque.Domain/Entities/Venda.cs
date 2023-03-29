using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class Venda : Entity
    {
        protected Venda() { }

        public Venda(Guid produtoId, string produtoNome, DateTime data, int quantidade)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Data = data;
            Quantidade = quantidade;
        }

        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public DateTime Data { get; private set; }
        public int Quantidade { get; private set; }
    }
}