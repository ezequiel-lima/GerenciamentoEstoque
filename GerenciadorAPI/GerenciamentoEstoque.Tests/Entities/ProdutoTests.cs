using GerenciamentoEstoque.Domain.Entities;
using System.Globalization;

namespace GerenciamentoEstoque.Tests.Entities
{
    [TestClass]
    public class ProdutoTests
    {
        [TestMethod]
        [DataRow("Mouse", "Mouse Gamer Ryu K", "15.0")]
        [DataRow("Teclado", "Teclado Gamer Ryu K", "50.50")]
        public void Deve_Retornar_Successo_Quando_Cadastrar_Produto(string nome, string descricao, string precoString)
        {
            decimal preco = decimal.Parse(precoString, CultureInfo.InvariantCulture);
            var produto = new Produto(nome, descricao, preco);

            //garante que o produto não é nulo
            Assert.IsNotNull(produto); 

            //garante que o valor dos parametros é iguais aos do objeto produto 
            Assert.AreEqual(nome, produto.Nome, "O nome do produto não foi definido corretamente.");
            Assert.AreEqual(descricao, produto.Descricao, "A descrição do produto não foi definida corretamente.");
            Assert.AreEqual(preco, produto.Preco, "O preço do produto não foi definido corretamente.");
        }
    }
}