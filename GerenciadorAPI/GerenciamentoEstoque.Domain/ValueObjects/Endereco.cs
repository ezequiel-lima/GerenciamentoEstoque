using GerenciamentoEstoque.Shared.ValueObjects;

namespace GerenciamentoEstoque.Domain.ValueObjects
{
    public class Endereco : ValueObject
    {
        public Endereco(string rua, string bairro, int numero, string cidade, string estado, int cep)
        {
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;           
        }

        public string Rua { get; private set; }
        public string Bairro { get; private set; }
        public int Numero { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public int Cep { get; private set; }
    }
}