using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.Infra.Data;
using GerenciamentoEstoque.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEstoque.WebApi.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> RecuperarProduto()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> RecuperarProdutoPorId(Guid id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> CadastrarProduto(Produto produto)
        {
            return await _service.Create(produto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> AtualizarProduto(Guid id, Produto produto)
        {
            return await _service.Put(id, produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Produto>> DeletarProduto(Guid id)
        {
            return await _service.Delete(id);
        }
    }
}