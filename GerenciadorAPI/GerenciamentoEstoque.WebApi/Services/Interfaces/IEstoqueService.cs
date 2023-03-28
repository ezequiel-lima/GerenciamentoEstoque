using GerenciamentoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEstoque.WebApi.Services.Interfaces
{
    public interface IEstoqueService
    {
        Task<ActionResult<IEnumerable<Estoque>>> GetAll();
        Task<ActionResult<Estoque>> GetById(Guid id);
        Task<ActionResult<Estoque>> Create(Estoque estoque);
        Task<ActionResult<Estoque>> Put(Guid id, Estoque estoque);
        Task<ActionResult<Estoque>> Delete(Guid id);
        Task<ActionResult<Estoque>> UpdateEstoqueQuantidade(Venda venda);
    }
}