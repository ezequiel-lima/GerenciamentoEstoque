using GerenciamentoEstoque.Domain.Entities;
using GerenciamentoEstoque.Infra.Data;
using GerenciamentoEstoque.WebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoEstoque.WebApi.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IReadRepository<Produto> _readRepositoryProduto;
        private readonly IWriteRepository<Estoque> _writeRepository;
        private readonly IReadRepository<Estoque> _readRepository;
        private readonly IUnitOfWork _unitOfWork;

        public EstoqueService(IReadRepository<Produto> readRepositoryProduto, IWriteRepository<Estoque> writeRepository, IReadRepository<Estoque> readRepository, IUnitOfWork unitOfWork)
        {
            _readRepositoryProduto = readRepositoryProduto;
            _writeRepository = writeRepository;
            _readRepository = readRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ActionResult<Estoque>> Create(Estoque estoque)
        {
            var produto = _readRepositoryProduto.FindByCondition(x => x.Id == estoque.ProdutoId).FirstOrDefault();

            if (produto is null)
                return new StatusCodeResult(404);

            var result = new Estoque(estoque.ProdutoId, estoque.QuantidadeProduto, produto.Nome);

            await _writeRepository.AddAsync(result);
            await _unitOfWork.CommitAsync();
            return result;
        }

        public async Task<ActionResult<Estoque>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult<IEnumerable<Estoque>>> GetAll()
        {
            return await _readRepository.FindAll().ToListAsync();
        }

        public async Task<ActionResult<Estoque>> GetById(Guid id)
        {
            var result = await _readRepository.FindByCondition (x => x.Id == id).FirstOrDefaultAsync();

            if (result is null)
                return new StatusCodeResult(404);

            return result;
        }

        public async Task<ActionResult<Estoque>> Put(Guid id, Estoque estoque)
        {
            throw new NotImplementedException();
        }
    }
}
