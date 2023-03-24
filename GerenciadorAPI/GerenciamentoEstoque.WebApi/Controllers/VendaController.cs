using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEstoque.WebApi.Controllers
{
    [Route("api/venda")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly IVendaService _service;

        public VendaController(IVendaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> RecuperarVenda()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> RecuperarVendaPorId(Guid id)
        {
            return await _service.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Venda>> CadastrarVenda(Venda venda)
        {
            return await _service.Create(venda);
        }
    }
}