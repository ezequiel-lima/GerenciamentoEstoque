using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class ItemPedido : Entity
    {
        protected ItemPedido() { }

        public ItemPedido(Produto produto, int quantidade, decimal precoUnitario)
        {
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        public Produto Produto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }
    }
}