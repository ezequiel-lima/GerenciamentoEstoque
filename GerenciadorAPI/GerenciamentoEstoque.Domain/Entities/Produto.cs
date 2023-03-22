using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class Produto : Entity
    {
        protected Produto() { }

        public Produto(string nome, string descricao, decimal preco)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }

        public void Alterar(Produto produto)
        {
            Nome = produto.Nome;
            Descricao = produto.Descricao;
            Preco = produto.Preco;
        }
    }
}