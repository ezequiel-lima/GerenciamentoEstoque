using GerenciamentoEstoque.Domain.Enums;
using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class Pedido : Entity
    {
        protected Pedido() { }

        public Pedido(DateTime dataCriacao, EStatusPedido statusPedido, IList<ItemPedido> itensPedidos)
        {
            DataCriacao = dataCriacao;
            StatusPedido = statusPedido;
            ItensPedidos = itensPedidos;
        }

        public DateTime DataCriacao { get; private set; }
        public EStatusPedido StatusPedido { get; private set; }
        public Fornecedor Fornecedor { get; private set; }
        public IList<ItemPedido> ItensPedidos { get; private set; }
    }
}