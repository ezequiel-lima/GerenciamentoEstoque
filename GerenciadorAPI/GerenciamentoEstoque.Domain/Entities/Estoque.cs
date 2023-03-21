using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class Estoque : Entity
    {       
        protected Estoque() { }

        public Estoque(Produto produto, int quantidadeProduto)
        {
            Produto = produto;
            QuantidadeProduto = quantidadeProduto;
        }

        public Produto Produto { get; private set; }
        public int QuantidadeProduto { get; private set; }
    }
}