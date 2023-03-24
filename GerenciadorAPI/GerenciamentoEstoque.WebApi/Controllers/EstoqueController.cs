using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEstoque.WebApi.Controllers
{
    [Route("api/estoque")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _service;

        public EstoqueController(IEstoqueService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estoque>>> RecuperarEstoque()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Estoque>> RecuperarEstoquePorId(Guid id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Estoque>> CadastrarEstoque(Estoque estoque)
        {
            return await _service.Create(estoque);
        }
    }
}