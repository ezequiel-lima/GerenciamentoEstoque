using GerenciamentoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEstoque.WebApi.Services.Interfaces
{
    public interface IVendaService
    {
        Task<ActionResult<IEnumerable<Venda>>> GetAll();
        Task<ActionResult<Venda>> GetById(Guid id);
        Task<ActionResult<Venda>> Create(Venda produto);
    }
}
