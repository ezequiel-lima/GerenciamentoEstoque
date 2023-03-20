using GerenciamentoEstoque.Domain.ValueObjects;
using GerenciamentoEstoque.Shared.Entities;

namespace GerenciamentoEstoque.Domain.Entities
{
    public class Fornecedor : Entity
    {
        protected Fornecedor() { }

        public Fornecedor(string nome, string telefone, Email email, Endereco endereco)
        {
            Nome = nome;
            Telefone = telefone;
            Email = email;
            Endereco = endereco;
        }

        public string Nome { get; private set; }
        public string Telefone { get; private set; }
        public Email Email { get; private set; }
        public Endereco Endereco { get; private set; }
    }
}