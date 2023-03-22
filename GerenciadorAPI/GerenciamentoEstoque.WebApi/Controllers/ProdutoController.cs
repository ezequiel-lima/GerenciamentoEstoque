using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.Infra.Data;
using GerenciamentoEstoque.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstoque.WebApi.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IReadRepository<Produto> _repository;
        private readonly IProdutoService _service;

        public ProdutoController(IReadRepository<Produto> repository, IProdutoService service)
        {
            _repository = repository;
            _service = service;
        }

        [HttpGet]
        public IActionResult RecuperarProduto()
        {
            return Ok(_repository.FindAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> RecuperarProdutoPorId(Guid id)
        {
            var result = await _repository.FindByCondition(x => x.Id == id).FirstOrDefaultAsync();

            if (result is null)
                return NotFound();

            return result;
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
    }
}