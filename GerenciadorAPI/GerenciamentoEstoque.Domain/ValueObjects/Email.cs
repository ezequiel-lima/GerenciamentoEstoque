using GerenciamentoEstoque.Shared.ValueObjects;

namespace GerenciamentoEstoque.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public Email(string enderecoEmail)
        {
            EnderecoEmail = enderecoEmail;
        }

        public string EnderecoEmail { get; private set; }
    }
}
