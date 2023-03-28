using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class Estoque : Entity
    {       
        protected Estoque() { }

        public Estoque(Guid produtoId, int quantidadeProduto, string produtoNome)
        {
            ProdutoId = produtoId;
            QuantidadeProduto = quantidadeProduto;
            ProdutoNome = produtoNome;
        }

        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int QuantidadeProduto { get; private set; }

        public void AtualizarEstoque(Venda venda)
        {
            QuantidadeProduto = QuantidadeProduto - venda.Quantidade;
        }
    }
}