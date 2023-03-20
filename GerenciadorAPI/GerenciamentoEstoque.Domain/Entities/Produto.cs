using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class Produto : Entity
    {
        protected Produto() { }

        public Produto(string nome, string descricao, decimal preco, int quantidadeEmEstoque, IList<Fornecedor> fornecedores)
        {
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
            Fornecedores = fornecedores;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public IList<Fornecedor> Fornecedores { get; private set; }
    }
}