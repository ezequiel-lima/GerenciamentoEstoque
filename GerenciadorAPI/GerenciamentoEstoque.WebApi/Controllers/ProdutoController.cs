using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.Infra.Data;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEstoque.WebApi.Controllers
{
    [Route("api/produto")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IReadRepository<Produto> _repository;

        public ProdutoController(IReadRepository<Produto> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_repository.FindAll());
        }
    }
}