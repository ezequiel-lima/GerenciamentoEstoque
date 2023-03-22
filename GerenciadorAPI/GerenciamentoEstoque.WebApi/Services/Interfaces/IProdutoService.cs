using GerenciamentoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEstoque.WebApi.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<ActionResult<IEnumerable<Produto>>> GetAll();
        Task<ActionResult<Produto>> GetById(Guid id);
        Task<ActionResult<Produto>> Create(Produto produto);
        Task<ActionResult<Produto>> Put(Guid id, Produto produto);
        Task<ActionResult<Produto>> Delete(Guid id);
    }
}