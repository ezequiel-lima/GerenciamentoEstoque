using GerenciamentoEstoque.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoEstoque.WebApi.Services.Interfaces
{
    public interface IProdutoService
    {
        Task<Produto> Create(Produto produto);
        Task<ActionResult<Produto>> Put(Guid id, Produto produto);
    }
}